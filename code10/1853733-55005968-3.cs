    public class EmailListDouble : List<Message>, IEmail
    {
        public void Send(Message message)
        {
            Add(message);
        }
    }
