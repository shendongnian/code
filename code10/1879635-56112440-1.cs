    using System.Web.Script.Serialization;
    namespace TestingAjax.Controllers
    {
        public class HomeController : Controller
        {
            [HttpPost]
            public void ButtonTest(string json)
            {
                var serializer = new JavaScriptSerializer();
                dynamic jsondata = serializer.Deserialize(json, typeof(object));
                //Get your Name variable here
                string name= jsondata["Name"];
                // Do something interesting here.
            }
    
            public IActionResult Index()
            {
                return View();
            }
        }
    }
