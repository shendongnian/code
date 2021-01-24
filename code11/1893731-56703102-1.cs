    using System.Web.Script.Serialization;
    [HttpPost]
    public JsonResult AddComment(string json)
    {
        if (ModelState.IsValid)
        {
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
            //Get your variables here from AJAX call
            string id= jsondata["id"];
            string comment=jsondata["comment"];
            // Do something here with your variables. 
        }
        return Json(true);
    }
