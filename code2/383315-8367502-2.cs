            struct User
            {
                public string Name;
                public string Address;
            }
    
           static void Main(string[] args)
           {
               Dictionary<string, User> hash = new Dictionary<string, User>();
              //To add to the hash
               hash.Add( "22255512282" , 
                    new User(){ Name = "foo" , Address = "Bar" });
              //To lookup by key
              User user;
              if (hash.TryGetValue("22255512282", out user))
              {
                 Console.WriteLine("Found " + user.Name);
              }
            
          }
