    List<int> intervals=new List<int>
    {
          10,11,12,13,14,15,16,17,18,19,20,21,22,23
     };
               
    List<int> Hours = Enumerable.Range(1,24).ToList();
            
     var NotInIntervals=Hours.Except(intervals).ToList();
                        
     foreach(var hour in NotInIntervals.OrderBy(x=>x))
      {
           Console.WriteLine(hour);
       }
