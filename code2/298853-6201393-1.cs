    public static void Main(string [] arg)
    {
        //create the list
        List<List<string>> listOfList = new List<List<string>>()
                                          {
                                              new List<string>()
                                                  {
                                                      "1.1","2.2"
                                                  }
                                          ,
                                           new List<string>()
                                                  {
                                                      "2.1","2.2","2.3"
                                                  }
                                          };
        //stopwatch using Linq
        Stopwatch stopwatch=new Stopwatch();
        stopwatch.Start();
        int totalUsingLinq = listOfList.Sum(x => x.Count);
        stopwatch.Stop();
        Console.WriteLine("Using Linq:{0}",stopwatch.Elapsed); //00005713
        int totalUsingFor = 0;
        //stopwatch using classic for 
        stopwatch.Reset();
        stopwatch.Start();
        totalUsingFor = 0;
        for(int i=0;i<listOfList.Count;i++)
        {
           var mainItem = listOfList[i];
            if(mainItem!=null)
            {
                totalUsingFor += mainItem.Count;
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Using for:{0}", stopwatch.Elapsed); //0000010
        
    }
