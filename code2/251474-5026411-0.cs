    using System.Globalization;
...
        
    string dateString, format;
            format = "M/dd/yyyy h:mm:ss tt";
            dateString = "2/17/2011 6:46:01 PM";
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture;
            result = DateTime.ParseExact(dateString, format, provider);
            Console.WriteLine(result.ToString());
