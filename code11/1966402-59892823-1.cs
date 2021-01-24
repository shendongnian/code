    using System.Web.Script.Serialization;
    
    [HttpPost]
    public JsonResult SaveData(string json) 
    {
        var serializer = new JavaScriptSerializer();
        dynamic jsondata = serializer.Deserialize(json, typeof(object));
        //Get your variables here from AJAX call
        var name= jsondata["name"];
        var pwd= jsondata["pwd"];
        var email= jsondata["email"];
        //Set your model here:
        SiteUser model=new SiteUser();
        model.name=name;
        model.pwd=pwd;
        model.email=email;
        //Perform db actions
        db.SiteUsers.Add(model);
        db.SaveChanges();
        BuildEmailTemplate(model.ID);
        return Json("Registration Successfull", JsonRequestBehavior.AllowGet); 
    }
