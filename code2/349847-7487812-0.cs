     int count=1; 
     foreach (var result in results)
                {
                    Console.WriteLine("XMaxResult = {0}", result.XMaxResult);
                    Console.WriteLine("XMinResult = {0}", result.XMinResult);
                    Console.WriteLine("YMaxResult = {0}", result.YMaxResult);
                    Console.WriteLine("YMinResult = {0}", result.YMinResult);
                    Console.WriteLine("ZMaxResult = {0}", result.ZMaxResult);
                    Console.WriteLine("ZMinResult = {0}", result.ZMinResult);
                   if(count%5==0)
                      Console.ReadLine();
                    count++;
                } 
