    using System.Web.Script.Serialization;
    
    var serializer = new JavaScriptSerializer();
    var deserialized = serializer.Deserialize<Dictionary<string, Dictionary<string, User>>>(theJsonString);
    var theUser = deserialized["newNickInfo"]["2775040"];
