    public class HomeController : Controller{
        public IActionResult Index(){
            return CreatedAtRoute("HelloDetails",new {Id=1} , new Student{
                Id = 1,
                StudentEmail = "test@microsoft.com"
            });
        }
    }
