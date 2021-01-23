     // Separate Encrypted DLL file
     public static class secureData()
     {
        public static string ConString = @"Data Source=YOUR_SERVER;Initial 
        Catalog=YOUR_DB;Persist Security Info=True;User 
        ID=YOUR_USER;Password=YOUR_PASSWORD";
     }
 
     public sampleDBEntities() : base("name=sampleDBEntities")
        {
            this.Database.Connection.ConnectionString =  secureData.ConString ;
        }
