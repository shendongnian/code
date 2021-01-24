                string[] dateStrs = {"Вс, 1 дек 2019 20:40:00 +0300","Вс, 1 дек 2019 20:50:00"};
                var ruRu = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
                string[] dateFormats = new string[]{
                    "ddd, d MMM yyyy HH:mm:ss",
                    "ddd, d MMM yyyy HH:mm:ss K",
                    "ddd, d MMM yyyy H:mm:ss",
                    "ddd, d MMM yyyy H:mm:ss K"
                };
                DateTime date;
                Boolean match = false;
                foreach (string dateStr in dateStrs)
                {
                    match = DateTime.TryParseExact(dateStr,dateFormats, ruRu, System.Globalization.DateTimeStyles.None, out date);
                    Console.WriteLine(date.ToString());
                }
                Console.ReadLine();
