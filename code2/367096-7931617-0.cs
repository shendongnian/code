    public class HomeController : Controller
    {
         public ActionResult Index()
         {
             var viewModel = new IndexViewModel();
    
             viewModel.State = "TX";
    
             return this.View(viewModel);
         }
    
             public static IList<StateCodeViewModel> getStatecodesDropDown()
             {
                 var stateCodes = new List<string> { "AX", "GH", "TX" };
    
                 var states = from p in stateCodes
                              select new StateCodeViewModel
                              {
                                  Value = p,
                                  Text = p
                              };
                 return states.ToList();
             }
        }
    
        public class IndexViewModel
        {
            public string State { get; set; }
        }
    
        public class StateCodeViewModel
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
