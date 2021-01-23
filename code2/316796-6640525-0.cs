    public abstract class Message {/*Implementation*/
     
          public enum MessageTypeEnum {Client, Viking, None};          
          public abstract MessageTypeEnum MessageType {get;}   
    }
    public class ClientMessage : Message {
          /*Client message concrete implementation.*/
           public override MessageTypeEnum MessageType 
           {
               get { 
                   return MessageTypeEnum.Client;
               } 
           }
    }
    public class VikingMessage : Message 
    {     
           / *Viking message concrete implementation*/
           public override MessageTypeEnum MessageType 
           {
               get { 
                   return MessageTypeEnum.Viking;
               } 
           }
    }
