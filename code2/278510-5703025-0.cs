    public class MyService : IService
    {
        private readonly IDependency1 dep1;
        private readonly IDependency2 dep2;
        private readonly IDependency3 dep3;
        public MyService(IDependency1 dep1, IDependency2 dep2,
            IDependency3 dep3)
        {
            this.dep1 = dep1;
            this.dep2 = dep2;
            this.dep3 = dep3;
        }
        void IService.DoOperation()
        {
           using (var context = dep1.CreateContext())
           {
               dep2.Execute(context);
               context.Commit();
           }
           dep3.Log("Success");
        }
    }
