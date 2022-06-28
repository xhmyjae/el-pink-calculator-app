using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basicCalculator
{
    public partial class Form1 : Form
    {
        private Rectangle OneButtonOriginalRectangle;
        private Rectangle TwoButtonOriginalRectangle;
        private Rectangle ThreeButtonOriginalRectangle;
        private Rectangle FourButtonOriginalRectangle;
        private Rectangle FiveButtonOriginalRectangle;
        private Rectangle SixButtonOriginalRectangle;
        private Rectangle SevenButtonOriginalRectangle;
        private Rectangle EightButtonOriginalRectangle;
        private Rectangle NineButtonOriginalRectangle;
        private Rectangle ZeroButtonOriginalRectangle;
        private Rectangle PlusButtonOriginalRectangle;
        private Rectangle MinusButtonOriginalRectangle;
        private Rectangle MultiplyButtonOriginalRectangle;
        private Rectangle DivideButtonOriginalRectangle;
        private Rectangle EqualButtonOriginalRectangle;
        private Rectangle ClearButtonOriginalRectangle;
        private Rectangle BackspaceButtonOriginalRectangle;
        private Rectangle DecimalButtonOriginalRectangle;
        private Rectangle SquareRootButtonOriginalRectangle;
        private Rectangle PlusMinusButtonOriginalRectangle;
        private Rectangle DisplayLabelOriginalRectangle;
        private Size OriginalFormSize;
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            OriginalFormSize = this.Size;
            OneButtonOriginalRectangle = new Rectangle(oneButton.Location.X, oneButton.Location.Y, oneButton.Width, oneButton.Height);
            TwoButtonOriginalRectangle = new Rectangle(twoButton.Location.X, twoButton.Location.Y, twoButton.Width, twoButton.Height);
            ThreeButtonOriginalRectangle = new Rectangle(threeButton.Location.X, threeButton.Location.Y, threeButton.Width, threeButton.Height);
            FourButtonOriginalRectangle = new Rectangle(fourButton.Location.X, fourButton.Location.Y, fourButton.Width, fourButton.Height);
            FiveButtonOriginalRectangle = new Rectangle(fiveButton.Location.X, fiveButton.Location.Y, fiveButton.Width, fiveButton.Height);
            SixButtonOriginalRectangle = new Rectangle(sixButton.Location.X, sixButton.Location.Y, sixButton.Width, sixButton.Height);
            SevenButtonOriginalRectangle = new Rectangle(sevenButton.Location.X, sevenButton.Location.Y, sevenButton.Width, sevenButton.Height);
            EightButtonOriginalRectangle = new Rectangle(eightButton.Location.X, eightButton.Location.Y, eightButton.Width, eightButton.Height);
            NineButtonOriginalRectangle = new Rectangle(nineButton.Location.X, nineButton.Location.Y, nineButton.Width, nineButton.Height);
            ZeroButtonOriginalRectangle = new Rectangle(zeroButton.Location.X, zeroButton.Location.Y, zeroButton.Width, zeroButton.Height);
            PlusButtonOriginalRectangle = new Rectangle(plusButton.Location.X, plusButton.Location.Y, plusButton.Width, plusButton.Height);
            MinusButtonOriginalRectangle = new Rectangle(minusButton.Location.X, minusButton.Location.Y, minusButton.Width, minusButton.Height);
            MultiplyButtonOriginalRectangle = new Rectangle(multiplyButton.Location.X, multiplyButton.Location.Y, multiplyButton.Width, multiplyButton.Height);
            DivideButtonOriginalRectangle = new Rectangle(divideButton.Location.X, divideButton.Location.Y, divideButton.Width, divideButton.Height);
            EqualButtonOriginalRectangle = new Rectangle(equalButton.Location.X, equalButton.Location.Y, equalButton.Width, equalButton.Height);
            ClearButtonOriginalRectangle = new Rectangle(clearButton.Location.X, clearButton.Location.Y, clearButton.Width, clearButton.Height);
            BackspaceButtonOriginalRectangle = new Rectangle(backspaceButton.Location.X, backspaceButton.Location.Y, backspaceButton.Width, backspaceButton.Height);
            DecimalButtonOriginalRectangle = new Rectangle(decimalButton.Location.X, decimalButton.Location.Y, decimalButton.Width, decimalButton.Height);
            SquareRootButtonOriginalRectangle = new Rectangle(squareRootButton.Location.X, squareRootButton.Location.Y, squareRootButton.Width, squareRootButton.Height);
            PlusMinusButtonOriginalRectangle = new Rectangle(plusMinusButton.Location.X, plusMinusButton.Location.Y, plusMinusButton.Width, plusMinusButton.Height);
            DisplayLabelOriginalRectangle = new Rectangle(displayLabel.Location.X, displayLabel.Location.Y, displayLabel.Width, displayLabel.Height);
        }
        
        private void Calculator_Resize(object sender, EventArgs e)
        {
            resizeButtons(OneButtonOriginalRectangle, oneButton);
            resizeButtons(TwoButtonOriginalRectangle, twoButton);
            resizeButtons(ThreeButtonOriginalRectangle, threeButton);
            resizeButtons(FourButtonOriginalRectangle, fourButton);
            resizeButtons(FiveButtonOriginalRectangle, fiveButton);
            resizeButtons(SixButtonOriginalRectangle, sixButton);
            resizeButtons(SevenButtonOriginalRectangle, sevenButton);
            resizeButtons(EightButtonOriginalRectangle, eightButton);
            resizeButtons(NineButtonOriginalRectangle, nineButton);
            resizeButtons(ZeroButtonOriginalRectangle, zeroButton);
            resizeButtons(PlusButtonOriginalRectangle, plusButton);
            resizeButtons(MinusButtonOriginalRectangle, minusButton);
            resizeButtons(MultiplyButtonOriginalRectangle, multiplyButton);
            resizeButtons(DivideButtonOriginalRectangle, divideButton);
            resizeButtons(EqualButtonOriginalRectangle, equalButton);
            resizeButtons(ClearButtonOriginalRectangle, clearButton);
            resizeButtons(BackspaceButtonOriginalRectangle, backspaceButton);
            resizeButtons(DecimalButtonOriginalRectangle, decimalButton);
            resizeButtons(SquareRootButtonOriginalRectangle, squareRootButton);
            resizeButtons(PlusMinusButtonOriginalRectangle, plusMinusButton);
            resizeButtons(DisplayLabelOriginalRectangle, displayLabel);
        }

        private void resizeButtons(Rectangle OriginalControlRect, Control control)
        {
            float xAxis = (float)(this.Width) / (float)(OriginalFormSize.Width);
            float yAxis = (float)(this.Height) / (float)(OriginalFormSize.Height);
            
            int newXPosition = (int)(OriginalControlRect.X * xAxis);
            int newYPosition = (int)(OriginalControlRect.Y * yAxis);
            
            
            int newWidth = (int)(OriginalControlRect.Width * xAxis);
            int newHeight = (int)(OriginalControlRect.Height * yAxis);
            
            control.Location = new Point(newXPosition, newYPosition);
            control.Size = new Size(newWidth, newHeight);
        }

        private float num1, num2, result;
        private char operation;
        private bool dec = false;

        private void changeLabel(int numPressed)
        {
            if(dec)
            {
                int decimalCount = 0;
                foreach (char c in displayLabel.Text)
                {
                    if (c == '.')
                    {
                        decimalCount++;
                    }
                }

                if (decimalCount < 1)
                {
                    displayLabel.Text = displayLabel.Text + ".";
                }

                dec = false;
            }
            else
            {
                if(displayLabel.Text.Equals("0") == true && displayLabel.Text != null)
                {
                    displayLabel.Text = numPressed.ToString();
                }
                else if(displayLabel.Text.Equals("-0") == true)
                {
                    displayLabel.Text = "-" + numPressed.ToString();
                }
                else
                {
                    displayLabel.Text = displayLabel.Text + numPressed.ToString();
                }
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            changeLabel(0);
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            changeLabel(1);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            changeLabel(2);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            changeLabel(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            changeLabel(4);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            changeLabel(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            changeLabel(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            changeLabel(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            changeLabel(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            changeLabel(9);
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            dec = true;
            changeLabel(0);
        }

        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "-" + displayLabel.Text;
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            if(num1 > 0)
            {
                double sqrt = Math.Sqrt(num1);
                displayLabel.Text = sqrt.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "0";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = '\0';
            dec = false;
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            int stringLength = displayLabel.Text.Length;
            if(stringLength > 1)
            {
                displayLabel.Text = displayLabel.Text.Substring(0, stringLength - 1);
            }
            else
            {
                displayLabel.Text = "0";
            }
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '*';
            result *= num1;
            displayLabel.Text = "";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '/';
            result /= num1;
            displayLabel.Text = "";
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '+';
            result += num1;
            displayLabel.Text = "";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '-';
            result -= num1;
            displayLabel.Text = "";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            result = 0;
            if(displayLabel.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case '+':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 + num2;
                        break;
                    case '-':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 - num2;
                        break;
                    case '*':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 * num2;
                        break;
                    case '/':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 / num2;
                        break;
                    default:
                        break;
                }
            }
            displayLabel.Text = result.ToString();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    equalButton.PerformClick();
                    break;
                case Keys.Back:
                    backspaceButton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    zeroButton.PerformClick();
                    break;
                case Keys.D0:
                    zeroButton.PerformClick();
                    break;
                case Keys.NumPad1:
                    oneButton.PerformClick();
                    break;
                case Keys.D1:
                    oneButton.PerformClick();
                    break;
                case Keys.NumPad2:
                    twoButton.PerformClick();
                    break;
                case Keys.D2:
                    twoButton.PerformClick();
                    break;
                case Keys.NumPad3:
                    threeButton.PerformClick();
                    break;
                case Keys.D3:
                    threeButton.PerformClick();
                    break;
                case Keys.NumPad4:
                    fourButton.PerformClick();
                    break;
                case Keys.D4:
                    fourButton.PerformClick();
                    break;
                case Keys.NumPad5:
                    fiveButton.PerformClick();
                    break;
                case Keys.D5:
                    fiveButton.PerformClick();
                    break;
                case Keys.NumPad6:
                    sixButton.PerformClick();
                    break;
                case Keys.D6:
                    sixButton.PerformClick();
                    break;
                case Keys.NumPad7:
                    sevenButton.PerformClick();
                    break;
                case Keys.D7:
                    sevenButton.PerformClick();
                    break;
                case Keys.NumPad8:
                    eightButton.PerformClick();
                    break;
                case Keys.D8:
                    eightButton.PerformClick();
                    break;
                case Keys.NumPad9:
                    nineButton.PerformClick();
                    break;
                case Keys.D9:
                    nineButton.PerformClick();
                    break;
                case Keys.Divide:
                    divideButton.PerformClick();
                    break;
                case Keys.Multiply:
                    multiplyButton.PerformClick();
                    break;
                case Keys.Subtract:
                    minusButton.PerformClick();
                    break;
                case Keys.Add:
                    plusButton.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}