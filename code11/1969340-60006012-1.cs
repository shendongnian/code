    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult AuthenticateUser(string json)
    {
    
      var serializer = new JavaScriptSerializer();
      dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
      //Get your variables here from AJAX call
      var username= jsondata["username"];
      var password= jsondata["password"];
      
      bool result=db.Authenticate(username,password) //Can be API call or DB call 
    
      if(bool)
      {
       return Json(new {status="true", msg= "successful authentication"}, JsonRequestBehavior.AllowGet);
      }
      else
      {
       return Json(new {status="false", msg= "Incorrect credentials given"}, JsonRequestBehavior.AllowGet);
      }
      
    }
