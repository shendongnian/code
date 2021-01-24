    class Answer
    {
        public string Text { get; set; }
        public bool Correct { get; set; }
    }
    
    class Question
    {
        public string Ques { get; set; }
        public string Type { get; set; }
        public List<Answer> Answers { get; set; }
    }
    
    class Tranzaction
    {
        public string TransactionId { get; set; }
        public List<Question> Questions { get; set; }
    }
