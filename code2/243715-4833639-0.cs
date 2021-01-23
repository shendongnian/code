    if (txtHour.Text != String.Empty)
    {
        int parsedValue;
        if (int.TryParse(txtHour.Text, out parsedValue))
        {
            time1.incrementHour(parsedValue);
        }
        else
        {
            // non-numeric value was entered into the textbox - handle accordingly.
        }
    }
