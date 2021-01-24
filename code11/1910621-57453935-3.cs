    public class Noun
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<Meaning> Meanings { get; set; }
    }
    public class Meaning
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<Noun> Nouns { get; set; }
    }
