    DateTime result;
    if(DateTime.TryParseExact(textBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result)
    {
        // Here you can safely use result
        string reformattedDate = result.ToString("yyyy/MM/dd");
    } else {
        // Screw the user
    }
