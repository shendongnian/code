    public class Normalized
    {
        public int userid { get; set; }
        public string name { get; set; }
        public List<NormalizedQuestion> questions { get; set; }
    }
    public class NormalizedQuestion
    {
        public int Question_no { get; set; }
        public string Question { get; set; }
    }
