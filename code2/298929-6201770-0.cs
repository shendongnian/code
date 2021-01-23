    System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
    try {
     DateTime.ParseExact(row.Cells[6].ToString(), "yyyy-MM-dd", enUS);
    }
    catch (FormatException) {
     ...your code instead of error...
    }
