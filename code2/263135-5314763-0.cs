            string dtString = "18/03/2011 15:16:57.487";
            
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");           
            DateTime dt = DateTime.Parse(dtString.Split('.')[0], culture);
            Double milliseconds = Double.Parse(dtString.Split('.')[1]);
            dt = dt.AddMilliseconds(milliseconds);
