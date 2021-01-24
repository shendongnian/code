    public class User_
      {
        public string Email { get; set; }
        public string Password { get; set; }
      }
    
      public class RootObject
      {
        public User_ User_ { get; set; }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          string jsonString = "{\"User_\":{\"Email\":\"test@test.com\",\"Password\":\"pass1\"}}";
          RootObject request = JsonConvert.DeserializeObject<RootObject>(jsonString.ToString());
          Console.WriteLine("Email: {0}", request.User_.Email);
          Console.WriteLine("Password: {0}", request.User_.Password);
          Console.ReadLine();
        }
      }
