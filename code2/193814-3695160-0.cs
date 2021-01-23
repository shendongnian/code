    public class User
    {
        public string Name { get; set; }
        public string TagLine { get; set; }
    }
    
    public class Account
    {
        public User Owner { get; set; }
    }
    
    // then...
    Console.WriteLine(account.Owner.Name);
    Console.WriteLine(account.Owner.TagLine);
