    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Obviously in a real world application the data is your domain model
            // and comes from a repository or a service layer depending on the complexity
            // of your application. I am hardcoding it here for the 
            // purposes of the demonstration
            var data = Enumerable.Range(1, 30).Select(x => new { Title = "title " + x });
            var model =
                from i in data.Select((value, index) => new { value, index })
                group i.value by i.index / 3 into g
                select new MyViewModel
                {
                    Items = g.Select(x => new ItemViewModel { Title = x.Title })
                };
            return View(model);
        }
    }
