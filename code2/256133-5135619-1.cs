     public class ServerItem
     {
       public string name { get; set; }
    
       public string ip { get; set; }
    
       public List<Channel> channels { get; set; }
     } 
    
     public class Channel
     {
       public string name { get; set; }
    
       public int port { get; set; }
    
       public int status { get; set; }
     }
