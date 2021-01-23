    string myName = "JOHN QUINCY PUBLIC";
    System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
    System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
    string convertedName = textInfo.ToTitleCase(myName.ToLower());
    Console.WriteLine(convertedName);
