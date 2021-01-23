     public class Program
        {
          public static void Main(string[] arg)
            {
                //create the list
                List<List<string>> listOfList = new List<List<string>>()
                                          {
                                              new List<string>()
                                                  {
                                                      "1.1","2.2","1.1","1.1","2.2","1.1","1.1","2.2","1.1","1.1"
                                                  }
                                          ,
                                           new List<string>()
                                                  {
                                                      "2.1","2.2","2.3","2.3","1.1","2.2","1.1","1.1","2.2","1.1","1.1","2.2","1.1","1.1","2.2","1.1","1.1","2.2","1.1"
                                                  }
                                          };
                //stopwatch using Linq
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
    
                int totalUsingLinq = listOfList.Sum(l => l.Distinct().Count());
    
    
                stopwatch.Stop();
                Console.WriteLine("Using Linq:{0}", stopwatch.Elapsed); //000012150    
                int totalUsingFor = 0;
                //stopwatch using classic for 
                stopwatch.Reset();
                stopwatch.Start();
                totalUsingFor = 0;
                for (int i = 0; i < listOfList.Count; i++)
                {
                    var mainItem = listOfList[i];
                    if (mainItem != null)
                    {
                        for(int y=0;y<mainItem.Count;y++)
                        {
                          if(mainItem[y]!=null)
                          {
                              totalUsingFor++;
                              NullDuplicateItems(y, ref mainItem);
                          }   
                        }
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("Using for:{0}", stopwatch.Elapsed); //0009440
            }
    
            public static void NullDuplicateItems(int index,ref List<string > list)
            {
                var item = list[index];
                for(int i=index+1;i<list.Count;i++)
                {
                    if(list[i]==item)
                    {
                        list[i] = null;
                    }
                }
            }
    
        }
