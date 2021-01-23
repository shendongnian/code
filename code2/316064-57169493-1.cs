     using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(user)))
     {
        // Deserialization from JSON  
        DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(UserListing))
        DataContractJsonSerializer(typeof(UserListing));
        UserListing response = (UserListing)deserializer.ReadObject(ms);
              
     }
     public class UserListing
     {
        public List<UserList> users { get; set; }      
     }
     public class UserList
     {
        public string FirstName { get; set; }       
        public string LastName { get; set; } 
     }
   
