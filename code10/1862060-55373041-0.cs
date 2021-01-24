    [WebMethod]
    public string loadEmployeeAccount(string json)
    {
    dynamic jsondata = serializer.Deserialize(json, typeof(object));
    string username = jsondata["email"]; 
    string password=jsondata["pass"]
    //Your code here
    }
