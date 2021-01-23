    class Client
    {
        static void Warn(object sender,InventoryChangeArgs args)
        {
            Console.WriteLine("It was changed by: {0] the {1}",args.Change,args.Pno);
        }
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.exe.config",false);
            InventoryManager inv=new InventoryManager();
            
            ConsoleReporter reporter = new ConsoleReporter();
    
            inv.Changed += reporter.InventoryManagerUpdatedCallback;
    
            Console.WriteLine("Client started");
            inv.UpdateInventory("102", 2);
            Console.ReadLine();
        }
    }
