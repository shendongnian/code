    public class MessageHelper
    {
        protected const String sessionName = "messages_session";
        public List<String> Messages 
        {
            get 
            {
                List<string> list;
                if (Session[sessionName] != null)
                {
                    list = (List<string>)Session[sessionName];
                }
                else 
                {
                    list = new List<string>();
                }
                Session[sessionName] = list;
                return list;
            }
            set 
            {
                Session[sessionName] = value;
            }
        }
        public void AddMessage(String message) 
        {
            List<String> list = this.Messages;
            list.Add(message);
            this.Messages = list;
        }
    }
