            DateTime dtnow = DateTime.Now;
            List<string> values =  new List<string>();
            if ( (dt <= dtnow))
            {
                values.Add(String.Format("{0:y}", dt));
            }
            while ( (dt = dt.AddMonths(1)) <= dtnow || ( dt.Month == dtnow.Month && dt.Year == dtnow.Year) )
            {                
                values.Add(String.Format("{0:y}", dt));  // "March, 2008"                     YearMonth
            }
            return values.ToArray();
          
        }
