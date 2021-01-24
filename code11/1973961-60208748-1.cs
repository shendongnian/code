    using System.Web.Script.Serialization
    [HttpPost]
    public JsonResult Create(string json)
    {
        var serializer = new JavaScriptSerializer();
        dynamic jsondata = serializer.Deserialize(json, typeof(object));
        List<string> myfieldName=new List<string>();
        //Access your array now
        foreach (var item in jsondata)
        {
          myfieldName.Add(item["myfieldName"]);
        }
    
        //Do something with the list here
        return Json("Success");
    }
