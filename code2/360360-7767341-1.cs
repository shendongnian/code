    class QuestionAndAnser
    {
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public QuestionAndAnser(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }
    }
    QuestionAndAnser[] questions = new QuestionAndAnser[] { 
        new QuestionAndAnser("What is the capital of France", "Paris"),
        new QuestionAndAnser("What is the capital of Spain", "Madrid"),
        // ...
    };
