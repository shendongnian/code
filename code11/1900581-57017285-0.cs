    while(true){
        Task.Factory.StartNew(() => seperateThreadToRunParralelLoop(ds));
         // Wait time i have to wait .......
    }
   
  
        function void seperateThreadToRunParralelLoop(ds)
                {
            Parallel.ForEach(ds.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = 30 }, drow =>
                  {
                  
                        if (!runningAccounts.Contains(username))
                        {  
                           runningAccounts.Add(username);
                           somefunction();
                           runningAccounts.remove(username);
                        }
                      });
                 }
               }
