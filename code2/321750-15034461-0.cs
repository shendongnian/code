    void Main()
    {
       User instance = new User();
       Type type = typeof(User);
    
       Dictionary<string, object> properties = new Dictionary<string, object>();
       foreach (PropertyInfo prop in type.GetProperties())
             properties.Add(prop.Name, prop.GetValue(instance));
       properties.Dump();    
    }
    
    // Define other methods and classes here        
    class User
    {
        private string foo;
        private string bar { get; set;}
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime Dob { get; private set; }
        public static int AddUser(User user)
        {    
            // add the user code
            return 1;
        }
    }
