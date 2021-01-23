    [WebMethod]
    public string HelloWorld(string sayHi)
    {
       if (string.IsNullOrEmpty(sayHi)                
           throw new ArgumentException("User not provided");
                
       return "String OK";
    }
