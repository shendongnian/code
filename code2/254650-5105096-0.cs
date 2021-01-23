     var groups = 
           Result.GroupBy(res => res.ID)
           .Select(x => Key=x.key, List=x.ToList());
      foreach (var group in groups)
      {
          Console.WriteLine("Key: " + group.key);
          foreach(var x in group.List){
             Console.WriteLine("Value: " + x);
          }
   
      }
