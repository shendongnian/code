        static void Main(string[] args)
        {
            BonjourServiceResolver bsr = new BonjourServiceResolver();
            bsr.ServiceFound += new Network.ZeroConf.ObjectEvent<Network.ZeroConf.IService>(bsr_ServiceFound);
            bsr.Resolve("_daap._tcp");
            Console.ReadLine();
        }
        static void bsr_ServiceFound(Network.ZeroConf.IService item)
        {
			// Here goes the code for what you want to do when a service is discovered
            Console.WriteLine(item);
        }
