    public class UserMessages
    {
        protected static string _messageSessionID = "userMessages";
    
        public static List<Message> GetMessages()
        {
            var msg = HttpContext.Current.Session[_messageSessionID];
    
            if (msg == null)
            {
                return new List<Message>();
            }
    
            //clear existing messages
            HttpContext.Current.Session[_messageSessionID] = null;
    
            //return messages
            return (List<Message>)msg;
        }
    
        public static void AddMessage(Message message)
        {
            var msg = GetMessages();
            msg.Add(message);
    
            HttpContext.Current.Session[_messageSessionID] = msg;
        }
    }
