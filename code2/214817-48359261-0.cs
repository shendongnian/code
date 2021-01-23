    public ActionResult MyMethod([System.Web.Http.FromBody] MyModel model)
    {
     if (module.Fields == null && !string.IsNullOrEmpty(Request.Form["fields"]))
     {
       model.Fields = JsonConvert.DeserializeObject<MyFieldModel[]>(Request.Form["fields"]);
     }
     //... more code
    }
