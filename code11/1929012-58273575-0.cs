    public class SampleEngine : BaseEngine
    {
         public override void Execute(Task task)
         {    
           System.Threading.Tasks.Task.Run(() =>
           {
             using (var someService = ServiceLocator.Current.GetInstance<IDbContext>())
             {
               // some action using dbcontext
             }
           });
         }
    }
