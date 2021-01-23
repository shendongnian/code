        System.DateTime now = System.DateTime.Now;
        System.Console.WriteLine(now);
        System.Globalization.CultureInfo culture = 
                 new System.Globalization.CultureInfo(1031); // de-DE
        System.Console.WriteLine(now.ToString(culture));
