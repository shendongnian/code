    public class App : HttpApplication
    {
      public ILifetimeScope RootLifetimeScope { get; private set; }
      protected void Application_Start()
      {
        var builder = new ContainerBuilder();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
        // save the reference to be able to access it later
        this.RootLifetimeScope = container;
        //...
      }
    }
 
    public class SomeController : Controller
    {
      private readonly Service service;
      public SomeController(Service service)
      {
        this.service = service;
      }
      public ActionResult Index(int id)
      {
        var model = new Model();
        model.Customer = this.service.Get(id);
    
        return View(model);
      }
    }
    Public class Service
    {
  
      private readonly DataAccess dataAccess;
      readonly ILifetimeScope _OwnScope;
      public Service(DataAccess dataAccess)
      {
        this.dataAccess = dataAccess;
      }
      public Customer Get(long id)
      {
        // Get the customer in a Synchronous way.
        var customer = dataAccess.Get(id);
  
        // Now we have to do something Async.
        // Solution: create a separate lifetime scope that survives longer than HTTP request
        Debug.Assert(HttpContext.Current != null)
        var newScope = ((App)HttpContext.Current.ApplicationInstance)
           .RootLifetimeScope.BeginLifetimeScope();
        // DO NOT use using statement or you'll have your original troubles
        try
        {
          var serv = newScope.Resolve<Service>();
          // the serv instance now will have its own DataAccess
          // which will be diposed only when newScope is disposed
 
          // Execute the call in a async way.
          new Action<long, long>(serv.DoSomething)
            .BeginInvoke(ar => 
              {
                // finish the action if required
                // DO NOT FORGET to dispose the scope, or you'll have a memory leak
                newScope.Dispose();              
              }, null);
        }
        catch
        {
          // dispose the scope only if something goes wrong.
          // if the code succeeds, you need to dipose the scope in the callback
          newScope.Dispose();
          throw;
        }
        return customer;
      }
      // This is the method we want to execute async.
      public void DoSomething()
      {
        // Do something short or long running.
      }
    }
