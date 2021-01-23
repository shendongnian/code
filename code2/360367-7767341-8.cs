    class QuestionAndAnswer
    {
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public QuestionAndAnswer(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }
    }
    QuestionAndAnswer[] questions = new QuestionAndAnswer[] { 
        new QuestionAndAnswer("What is the capital of France", "Paris"),
        new QuestionAndAnswer("What is the capital of Spain", "Madrid"),
        // ...
    };
    // use: questions[0].Question, questions[0].Answer...
