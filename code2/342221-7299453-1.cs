    public class ChatData
    {
         public ChatData()
         {
             TimeStamp = DateTime.Now;
         }
         public int ID { get; set; }
         public string Who { get; set; }
         public string Said { get; set; }
         public DateTime TimeStamp { get; set; }
    }
    ...
    var data = new List<ChatData>
    {
        new ChatData { ID = 1, Who = "bob", Said = "hey guys" },
        ...
    };
    return Response.AsJson( data );
