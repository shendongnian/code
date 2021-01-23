            struct User
            {
                public string Name;
                public string Address;
            }
    
            static void Main(string[] args)
            {
                Dictionary<string, User> hash = new Dictionary<string, User>();
    
                hash.Add( "22255512282" , 
                        new User(){ Name = "foo" , Address = "Bar" };
            }
