    class SamPointOfContact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
    }
    class Naics
    {
        public string naicsName { get; set; }
        public string hasSizeChanged { get; set; }
        public bool isPrimary { get; set; }
        public int ExcpCounter { get; set; }
        public string isSmallBusiness { get; set; }
        public int naicsCode { get; set; }
    }
    class Answer
    {
        public string answerText { get; set; }
        public string section { get; set; }
        public SamPointOfContact samPointOfContact { get; set; }
        public Naics[] naics { get; set; }
    }
    
    class AnswerNode
    {
        [JsonConverter(typeof(SingleValueArrayConverter<Answer>))]
        public Answer[] answers { get; set; }
        public string id { get; set; }
    }
    class Root
    {
        public AnswerNode[] listOfAnswers { get; set; }
    }
