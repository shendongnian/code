    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult SaveRecords(string json)
    {
    
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            var zoom = jsondata["zoom"];
            var lat1 =jsondata["lat1"];
    
            //Do something with your variables here    
    
        return Json("Success");
    }
