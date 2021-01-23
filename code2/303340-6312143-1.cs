    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            For< ManagerBase >().Use< Manager1 >().Named("A");
            For< ManagerBase >().Use< Manager2 >().Named("B");
            For< ManagerBase >().Use< Manager3 >().Named("C");
        }
    }
