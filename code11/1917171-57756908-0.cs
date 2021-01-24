    //this service in need of tests. You must test it's methods.
    public class ProductionService: IProductionService
    {
        private readonly IImSomeDependency _dep;
        public ImTested(IImSomeDependency dep){ _dep = dep; }
        public void PrintStr(string str)
        {
            Console.WriteLine(_dep.Format(str));
        }
    }
    
    //this is stub dependency. It contains anything you need for particular test. Be it some data, some request, or just return NULL.
    public class TestDependency : IImSomeDependency
    {
        public string Format(string str)
        {
            return "TEST:"+str;
        }
    }
    
    //this is production, here you send SMS, Nuclear missle and everything else which cost you money and resources.
    public class ProductionDependency : IImSomeDependency
    {    
        public string Format(string str)
        {
            return "PROD:"+str;
        }
    }
