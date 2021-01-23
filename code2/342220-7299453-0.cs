    public class ChatData
    {
         public ChatData()
         {
             TimeStamp = DateTime.Now;
         }
         public string Who { get; set; }
         public string Said { get; set; }
         public DateTime TimeStamp { get; set; }
    }
    ...
    var data = new List<ChatData>
    {
        new ChatData { Who = "bob", Said = "hey guys" },
        ...
    };
    return Response.AsJson( data );
