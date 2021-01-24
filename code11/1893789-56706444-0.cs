    public class Contact
    {
        public string ID { get; }
        public List<Intent> Intents {get; set;}
    
        public Contact(string id) { ID = id; Intents = new List<Intent>(); }
    }
    
    public class Intent
    {
        public List<string> Transcripts {get; set;}
        public string Name { get; }
        public Intent(string name) { Name = name; Transcripts = new List<Transcript>(); }
    }
