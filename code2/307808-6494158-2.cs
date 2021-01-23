    namespace UserNotification
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.Web.Script.Services.ScriptService]
        public class MessageService : System.Web.Services.WebService
        {
    
            public MessageService()
            {
            }
    
            [WebMethod(EnableSession = true)]
            public List<Message> GetMessages()
            {
                return UserMessages.GetMessages();
            }
        }
    }
