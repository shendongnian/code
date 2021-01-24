    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult GetModel(string json)
    {
    
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            var chart= jsondata["chart"];
            var value=jsondata["value"];
            //Do something with your variables here    
    
        return Json("Success");
    }
