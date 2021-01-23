    public ActionResult MyAction(string search)
    {
    //do whatever you need with the parameter, 
    //like using it as parameter in Linq to Entities or Linq to Sql, etc. 
    //Suppose your search result will be put in variable "result".
    ViewData.Model = result;
    return View();
    }
