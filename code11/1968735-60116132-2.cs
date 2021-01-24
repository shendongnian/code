     public class TestController : Controller
        {
            // GET: Test
            public ActionResult Index()
            {
                TestModel t = new TestModel();
                t.TestList = new List<TestItem>();
                return View(t);
            }
        }
    
        public class TestModel
        {
            public List<TestItem> TestList { get; set; }
    
            public string AnyMethod()
            {
                return "";
            }
        }
    
        public class TestItem
        {
            public string S { get; set; }
        }
