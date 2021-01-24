    public class standardMessage
    {
        public standardMessage()
        {
            message = new messageProperties();
            flag = new messageFlags();
        }
        public messageProperties message { get; set; } = new messageProperties();
        public messageFlags flag { get; set; } = new messageFlags();
    }
