    public class MyController : Controller
    {
        public MainLayoutViewModel MainLayoutViewModel { get; set; }
        public MyController()
        {
            this.MainLayoutViewModel = new MainLayoutViewModel();//has property PageTitle
            this.MainLayoutViewModel.PageTitle = "my title";
            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
        }
       
    }
