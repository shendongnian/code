    public class User
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string AnotherProperty { get; set;}
    }
    
    
    Dictionary<string, User> userTable = new Dictionary<string, User>();
    
    userTable.Add(userName, new User(){Name = "fred", IPAddress = "127.0.0.1", AnotherProperty = "blah"});
