    void Main()
     {
     var list = new List<DateTime>
     {
      new DateTime(2005, 10, 11),
      new DateTime(2009, 3, 4),
      new DateTime(2010, 5, 8),
      new DateTime(2010, 8, 10),
      DateTime.Now,
      new DateTime(2010, 4, 8)
     };
    
            var result= Enumerable.Range(list.Min (l => l.Year), list.Max (l => l.Year) - list.Min (l => l.Year)).
                 SelectMany (e => Enumerable.Range(1, 12).Select (en => new DateTime(e, en, 1))).
                 Except(list.Select(o => new DateTime(o.Year, o.Month, 1))).
                 Where (o => o.Date > list.Min (l => l.Date) && o.Date < list.Max (l => new DateTime(l.Year, l.Month, 1)));
        
        }
