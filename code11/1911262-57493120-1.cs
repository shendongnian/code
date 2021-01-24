    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult ProcessMyValue(string json)
    {
    
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            var SortSelected= jsondata["selectedText"];
    
            //Do something with your variables here. I am assuming this:
 
            var sortedArticles = ListOfPosts.OrderBy(x => x.GetPropertyValue<DateTime>("articleDate")).Reverse().ToList();
    
            if (SortSelected == "Most recent")
            {
             sortedArticles = ListOfPosts.OrderBy(x => x.GetPropertyValue<DateTime>("articleDate")).Reverse().ToList();
            }
            else if (SortSelected == "Oldest")
            {
              sortedArticles = ListOfPosts.OrderBy(x => x.GetPropertyValue<DateTime>("articleDate")).ToList();
            }  
    
        return Json(new { success = true, sortedArticles }, JsonRequestBehavior.AllowGet);
    }
