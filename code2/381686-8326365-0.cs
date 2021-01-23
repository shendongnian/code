    public interface IParser
    {
        Message Parse(String Payload);
    }
     // Position Class
     public class Position
     {
     public int X { get; private set; }
     public int Y { get; private set; }
     public int Z { get; private set; }
     public Position(int X, int Y, int Z)
     {
      this.X = X;
      this.Y = Y;
      this.Z = Z;
     }
    }
    // Message Class 
    public class Message
    {
     public String ID { get; private set; }
     public Position Position { get; private set; }
     public Message(String ID, Position Position)
     {
       this.ID = ID;
       this.Position = Position;
     }
    }
     // Parser Class
     public class XMLParser : IParser
    {
     public Message Parse(string Payload)
     {
      var result = XElement.Parse(Payload);
      return new Message(result.Elements().ElementAt(0).Value, new Position(X,Y,Z);
     }
    }
    
