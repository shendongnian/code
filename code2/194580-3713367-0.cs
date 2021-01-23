    string input = "45053";
    decimal result;
    if (decimal.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result))
    {
        result /= 100M;
    }
    else
    {
        // invalid input, handle in whatever way you deem appropriate
    }
