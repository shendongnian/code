     class Program
        {
            static void Main(string[] args)
            {
    
                Task<int> task  = Task<int>.Factory.StartNew(() =>
                    {
                        Exporter exporter = new Exporter();
                        int i = exporter.StartExport();
                        return i;
                     });
    
                int iResult = task.Result;
                Console.WriteLine(iResult);
                Console.ReadLine();
    
                
            }
    
            class Exporter {
                public int StartExport()
                {
                    //simulate some work
                    System.Threading.Thread.Sleep(500);
                    return 5;
                }
            }
        }
