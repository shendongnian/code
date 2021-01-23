    public class WorkFlowException : Exception
    {
        List<string> messages;
        public WorkFlowException(List<string> messages)
        { 
          this.messages = messages
        }
        public override string Message
        {
          get { return messages != null && messages.Count > 0 ? messages[0] : "" }
        }
    }
