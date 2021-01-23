    class ResponseEntity
    {
        private Info info;
        private int received;
        private int valid;
        [JsonProperty("info")]
        public Info Info
        {
            get { return info; }
            set { info = value; }
        }
        [JsonProperty("valid")]
        public int Valid
        {
            get { return valid; }
            set { valid = value; }
        }
        [JsonProperty("received")]
        public int Received
        {
            get { return received; }
            set { received = value; }
        }
    }
    public class Info
    {
        private int calls;
        private List<string> errors;
        private int messages;
        private int mail;
        [JsonProperty("calls")]
        public int Calls
        {
            get { return calls; }
            set { calls = value; }
        }
        [JsonProperty("messages")]
        public int Messages
        {
            get { return messages; }
            set { messages = value; }
        }
        [JsonProperty("errors")]
        public List<string> Errors
        {
            get { return errors; }
            set { errors = value; }
        }
        [JsonProperty("mail")]
        public int Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
