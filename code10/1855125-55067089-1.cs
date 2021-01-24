    private void HowToMethod(string tm, Team values)
    {
        var yearControlName = tm + "Year";
        foreach(var ctrl in Controls)
        {
            if (ctrl is TextBox)
            {
                var tb = (ctrl as TextBox);
                if (tb.Name == yearControlName)
                    tb.Text = values.EstYear.ToString();
            }
        }
    }
