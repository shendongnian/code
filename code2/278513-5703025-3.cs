    public class MyService : IService
    {
        public MyService(IDependency1 dep1, 
            IDependency2 dep2, IDependency3 dep3)
        {
        }
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
