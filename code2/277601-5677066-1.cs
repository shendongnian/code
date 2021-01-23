    class FbUser()
    {
       public string id { get;set;}
       public string name { get;set;}
       public string first_name { get;set;}
      .... a property name for every data element in the returned record.
    }
    
    
    Dictionary<string,FbUser> userlist = JsonConvert.DeserializeObject<Dictionary<string,FbUser>();
