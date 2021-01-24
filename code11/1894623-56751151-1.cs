    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult getRequirmentsByProject(string json)
    {
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            string projectname= jsondata["projectname"];    
        
        return Json(projectname);
    }
