    series.Skip(period-1).Aggregate(
      new {
        Result = new SortedList<DateTime, double>(), 
        Working = List<double>(series.Take(period-1).Select(item => item.Value))
      }, 
      (list, item)=>{
         list.Working.Add(item.Value); 
         list.Result.Add(item.Key, list.Working.Average()); 
         list.Working.RemoveAt(0);
         return list;
      }
    ).Result;
