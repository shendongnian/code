    private bool isValueEnteredExceed100(string textBoxValue, string inputText)
    {
        var countPeriod = textBoxValue.Count(x => x.ToString().Equals("."));
        if (countPeriod <= 1)
        {
            bool isValidNumber = AreAllValidNumericChars(inputText);
            
            if (isValidNumber == true || inputText == ".")
            {
                double enterdValue;
                bool returnValue = false;
                if (textBoxValue != string.Empty || textBoxValue != "")
                {
                    enterdValue = Convert.ToDouble(textBoxValue);
                    if (enterdValue > 0 && enterdValue <= 100)
                    {
                        returnValue = true;
                    }
                }
                return returnValue;
            }
            else
            {
                return isValidNumber;
            }
        }
        else
        {
            return false;
        }
    }
    private void AcceptedFromTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string textBoxValue = AcceptedFromTextBox.Text + e.Text;
        if (textBoxValue == ".")
        {
            textBoxValue = "0" + e.Text;
            AcceptedFromTextBox.Text = textBoxValue;
        }
        e.Handled = !isValueEnteredExceed100(textBoxValue, e.Text);
        AcceptedFromTextBox.SelectionStart = AcceptedFromTextBox.Text.Length;
    }
    private bool AreAllValidNumericChars(string str)
    {
        Regex regex = new Regex(@"[0-9]$");
        return regex.IsMatch(str);
    }
