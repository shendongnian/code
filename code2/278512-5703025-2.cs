    public class MyService : IService
    {
        // Boilerplate!
        private readonly IDependency1 dep1;
        private readonly IDependency2 dep2;
        private readonly IDependency3 dep3;
        public MyService(IDependency1 dep1, IDependency2 dep2,
            IDependency3 dep3)
        {
            // More boilerplate!
            this.dep1 = dep1;
            this.dep2 = dep2;
            this.dep3 = dep3;
        }
        // Finally something useful
        void IService.DoOperation()
        {
           using (var context = this.dep1.CreateContext())
           {
               this.dep2.Execute(context);
               context.Commit();
           }
           this.dep3.Log("Success");
        }
    }
