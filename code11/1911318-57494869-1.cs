    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult Answer(string json)
    {
    
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            var message= jsondata["messageVariable"];
    
            //Do something with your variables here.
   
        return Json(new { success = true, messageVariable }, JsonRequestBehavior.AllowGet);
    }
