    public class Object
    {
       public string Username { get; set; }
       public string Item { get; set; }
       public string Amount { get; set; }
       public string Complete { get; set; }
    }
    
    Object a = new Object();
    a.Username = Reader['Username'].ToString();
