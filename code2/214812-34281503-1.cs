    [HttpPost]
    public JsonResult TheAction(string data) {
           
           string _jsonObject = data.Replace(@"\", string.Empty);
           var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();           
            Dictionary<string, string> jsonObject = serializer.Deserialize<Dictionary<string, string>>(_jsonObject);
            
            return Json(new object{status = true});
        }
      
