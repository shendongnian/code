    maybe better (without shouffling, without repeatable questions):       
  
      
    class QuizQuestion
    {
    public string Question {get; set;}
    public string Answer {get; set;}
    }
    
    static Random _r = new Random();        
            static int Quiz()
            {
                QuizQuestion[] QAndA = new QuizQuestion[] {
                    new QuizQuestion() {Question = "What is the capital of France", Answer = "Paris"},
                    new QuizQuestion() {Question = "What is the capital of Spain", Answer ="Madrid"},
                            ...
                    new QuizQuestion() {Question = "What is the captial of Russia", Answer ="Moscow"},
                    new QuizQuestion() {Question = "What is the capital of Ukraine", Answer ="Kiev"},
                };
        
                var questions = QAndQ.ToList();
                for (int i = 0; i < NUM_QUESTIONS; i++)
                {
                    int num = _r.Next(questions.Length / 2);
                    Question(questions[num].Question, questions[num].Answer);
                    questions.Remove(questions[num]);
                }
            }
