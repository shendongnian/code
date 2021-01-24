    public class HomeController : Controller
    {       
        private readonly MyConfigModel _myConfigModel2;
        public HomeController(MyConfigModel myConfigModel)
        {
            _myConfigModel2 = myConfigModel;
        }              
    }
