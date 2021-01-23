    DateTime result = DateTime.Now;
    if(DateTime.TryParseExact(textBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out res)
    {
        // here you can safely use result
        string dbDate = result.ToString("yyyy/MM/dd");
    } else {
        // Screw the user
    }
