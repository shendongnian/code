    ```c#
    public class Result
    {
        public bool Succeeded {get; set;}
        public string StatusMessage {get; set;}
        public IList<LogMessage> LogMessages {get; set;} = new List<LogMessage>();
    }
