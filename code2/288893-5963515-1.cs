    string numValue = "500,85";
    System.Globalization.CultureInfo culInfo = new System.Globalization.CultureInfo("fr-FR");
    decimal decValue;
    bool decValid = decimal.TryParse(numValue, System.Globalization.NumberStyles.Number, culInfo.NumberFormat, out decValue);
    if (decValid)
    {
        lblDecNum.Text = Convert.ToString(decValue, culInfo.NumberFormat);
    }
