    public class Contact
    {
        public string ID { get; }
        public IList<Intent> Intents { get; }
    
        public Contact(string id) { ID = id; Intents = new List<Intent>(); }
    }
    
    public class Intent
    {
        public IList<string> Transcripts { get; }
        public string Name { get; }
        public Intent(string name) { Name = name; Transcripts = new List<Transcript>(); }
    }
