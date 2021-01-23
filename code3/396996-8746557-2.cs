    //obj is your JSON string
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    Dictionary<string,object> csObj = 
        serializer.Deserialize<Dictionary<string,object>>(obj);
    int length = ((ArrayList)csObj["data"]).Count; 
