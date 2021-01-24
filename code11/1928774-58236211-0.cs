    static void Main(string[] args)
    {                
      List<Dates> dates = Dates.GetDates();
      List<DateTime> lstTimeLine = GenerateTimeLine(dates[0].Time, dates[dates.Count-1].Time, 10);
                           
      List<Dates> lstInterpolated = new List<Dates>();
      foreach(var itm in lstTimeLine)
      {
           var target = itm;
           Console.WriteLine("############################ X = " + itm);
           var smaller = dates.Last(x => x.Time <= target);
           var bigger = dates.FirstOrDefault(x => x.Time >= target);
           if (bigger == null)
               bigger = smaller;
    
           Console.WriteLine(smaller.ID + " " + smaller.Time + " " + smaller.Value);
           Console.WriteLine(bigger.ID + " " + bigger.Time + " " + bigger.Value); }
    }
