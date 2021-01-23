     private List<Tuple<int,int>> year_month_Between(DateTime d0, DateTime d1)
        {
            List<DateTime> datemonth= Enumerable.Range(0, (d1.Year - d0.Year) * 12 + (d1.Month - d0.Month + 1))
                             .Select(m => new DateTime(d0.Year, d0.Month, 1).AddMonths(m)).ToList();
         List<Tuple<int, int>> yearmonth= new List<Tuple<int,int>>();
    
            foreach (DateTime x in datemonth)
            {
                yearmonth.Add(new Tuple<int, int>(x.Year, x.Month));
            }
            return yearmonth;
        }
