    public class EncryptedString
    {
      public string Value { get;private set; }
      public string Hash { get;private set; }
      bool Validate(string password);
     
      public Encrypted(string value)
      {
         // Put logic here
      }
    }
