    public class MyService : IService
    {
        public MyService(private IDependency1 dep1, 
            private IDependency2 dep2, private IDependency3 dep3)
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
