    public class Noun
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<NounMeaning> NounMeanings { get; set; }
    }
    public class Meaning
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<NounMeaning> NounMeanings { get; set; }
    }
    public class NounMeaning
    {
        public int NounId { get; set; }
        public int MeaningId { get; set; }
        public Noun Noun { get; set; }
        public Meaning Meaning { get; set; }
    }
