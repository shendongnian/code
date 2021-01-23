    System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            
    System.Collections.Generic.Dictionary<string, object> dict = ser.DeserializeObject(@"{""key"":""value""}") as System.Collections.Generic.Dictionary<string, object>;
            
    Console.WriteLine(dict["key"].ToString());
