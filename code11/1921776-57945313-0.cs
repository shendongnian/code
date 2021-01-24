                ArrayList urlList = new ArrayList();
                Console.WriteLine("Enter Month Number");
                var month = Console.ReadLine();
                Console.WriteLine("Enter Day Start");
                var daystart = Console.ReadLine();
                int ds = Int32.Parse(daystart);
                Console.WriteLine("Enter Day End");
                var dayend = Console.ReadLine();
                int de = Int32.Parse(dayend);
                var dayList = Enumerable.Range(ds, de).ToList();
                dayList.ForEach(Console.WriteLine);
                foreach (var days in dayList)
                {     
                    urlList.Add("https://www.norwegian.com/uk/ipc/availability/avaday?AdultCount=1&A_City=RIX&D_City=OSL&D_Month=2019" + month + "&D_Day=" + days + "&IncludeTransit=false&TripType=1&CurrencyCode=GBP");
                }
                foreach (string url in urlList)
                {
                    driver.Navigate().GoToUrl(url);
                }
