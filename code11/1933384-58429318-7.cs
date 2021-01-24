    class Program
        {
            static void Main(string[] args)
            {
                Mssql<Bank> TEST = new Mssql<Bank>();
                List<Bank> TheList = TEST.ReadTable();
    
    
                foreach (var item in TheList)
                {
                    Console.WriteLine(item.LfdNr);
                    Console.WriteLine(item.Kennung);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Ort);
                    Console.WriteLine(item.PLZ);
                    Console.WriteLine(item.Straße);
                    Console.WriteLine(item.TSCREATE);
                    Console.WriteLine(item.TSUPDATE);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
    
                }
    
                Console.ReadLine();
    
            }
        }
