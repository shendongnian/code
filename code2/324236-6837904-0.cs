    for (int i = 2000; i < 2100; i++)
     {
           string year = i + "0101";
           DateTime pt = DateTime.ParseExact(year, "yyyyMMdd", null);
           Console.WriteLine("{0}. {1}", (i-1999), pt.ToShortDateString());
     }
