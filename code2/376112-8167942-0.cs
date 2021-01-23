        public class SearchController : Controller
        {
            [HttpPost]
            public ActionResult Search(SearchViewModel model)
            {
                // perform search based on model.Query
                // return a View with your Data.
            }
        }
