    public class MyController : Controller
    {
        private IDBChooser dbChooser;
        public MyController(IDBChooser dbChooser)
        {
            this.dbChooser = dbChooser;
        }
    }
    //In startup 
    services.AddSingleton<IDBChooser, MyDbChooser>();
