    public class YourObjectName
    {
       public string Username { get; set; }
       public string Item { get; set; }
       public string Amount { get; set; }
       public string Complete { get; set; }
    }
    
    YourObjectName a = new YourObjectName();
    a.Username = Reader['Username'].ToString();
