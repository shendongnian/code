    public class SomeController : Controller
    {
      private readonly DataAccess dataAccess;
      private readonly Func<Owned<DataAccess>> dataAccessFactory;
      public SomeController(DataAccess dataAccess, Func<Owned<DataAccess>> dataAccessFactory)
      {
        this.dataAccess = dataAccess;
        this.dataAccessFactory = dataAccessFactory;
      }
      public ActionResult Index(int id)
      {
        var model = new Model();
        model.Customer = this.dataAccess.Get(id);
        Owned<DataAccess> dataAccessForAsyncTaskHolder = null;
        try
        {
          dataAccessForAsyncTaskHolder = dataAccessFactory();
          dataAccessForAsyncTaskHolder.Value.ExecuteAsyncTask(() =>
            // you'll need a completion callback
            {
              // finish the task if required
              // dipose the owned instance
              dataAccessForAsyncTaskHolder.Dispose();
            });
        }
        catch
        {
          if (dataAccessForAsyncTaskHolder != null)
            dataAccessForAsyncTaskHolder.Dispose();
          throw;
        }
        return View(model);
      }
    }
