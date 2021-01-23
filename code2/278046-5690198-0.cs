    class Question
    {
         public string QuestionText {get;}
         public Answer AnswerA { get; }
         public Answer AnswerB { get; }
         public Answer AnswerC { get; }
         public Answer AnswerD { get; }
         public Answer ChosenAnswer { get;set;}
    }
    class Answer
    {
        public string AnswerText { get; }
    }
