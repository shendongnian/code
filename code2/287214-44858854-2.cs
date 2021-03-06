    public class NumericUpDownUnit : System.Windows.Forms.NumericUpDown
        {
            
            public string Suffix{ get; set; }
            private bool Debounce = false;
            public NumericUpDownUnit()
            {
            }
            protected override void ValidateEditText()
            {
                if (!Debounce) //I had to use a debouncer because any time you update the 'this.Text' field it calls this method.
                {
                    Debounce = true; //Make sure we don't create a stack overflow.
                    string tempText = this.Text; //Get the text that was put into the box.
                    string numbers = ""; //For holding the numbers we find.
                    foreach (char item in tempText) //Implement whatever check wizardry you like here using 'tempText' string.
                    {
                        if (Char.IsDigit(item))
                        {
                            numbers += item;
                        }
                        else
                        {
                            break;
                        }
                    }
                    decimal actualNum = Decimal.Parse(numbers, System.Globalization.NumberStyles.AllowLeadingSign);
                    if (actualNum > this.Maximum) //Make sure our number is within min/max
                        this.Value = this.Maximum;
                    else if (actualNum < this.Minimum)
                        this.Value = this.Minimum;
                    else
                        this.Value = actualNum; 
                    ParseEditText(); //Carry on with the normal checks.
                    UpdateEditText();
                    Debounce = false;
                }
                
            }
            protected override void UpdateEditText()
            {
                // Append the units to the end of the numeric value
                this.Text = this.Value + Suffix;
            }
        }
