    public class SearchController
    {
        public ActionMethod Search(SearchModel searchCriteria)
        {
               SearchResultModel result= //Get the search results from database
               return new JsonResult{Data=result};
        }
    }
    
