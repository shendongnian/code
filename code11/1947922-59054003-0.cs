    public class MyClass
    {
        private string email;
        
       [JsonProperty(Required = Required.Always)]
       public string Name { get; set; }
       [JsonProperty(Required = Required.Always)]
       public string Email { 
           get
           {
               return email;
           }
           set
           {
               var address = new MailAddress(value); 
               email = value;
           }
       }
    }
