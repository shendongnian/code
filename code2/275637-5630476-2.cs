    public class WorkFlowException : Exception
    {
        public WorkFlowException(List<string> messages)
        : base(messages != null && messages.Count > 0 ? messages[0] : "")
        { 
          //...
        }
    }
