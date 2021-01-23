            string format = "dd.MM.yyyy HH:mm:ss.fff";
            string c = "12.01.2011 13:26:10.000";
            CultureInfo enUS = new CultureInfo("en-US");
            
            DateTime result;
            if (DateTime.TryParseExact(c, format, enUS, DateTimeStyles.None, out result))
            {
                Console.WriteLine("Right Format");
            }
            else
            {
                Console.WriteLine("Wrong Format");                
            }
