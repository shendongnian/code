    class Question
    
    {
        string ImageURI { get; set; }
        string Text { get; set; }
        ObservableCollection<Answer> Answers { get; set; }
        Answer CorrectAnswer { get; set; }
        
        bool MakeGuess(Answer a) { UserGuess = a; if (a.Equals(CorrectAnswer)) {  return true; } return false; }
        
        bool AnsweredSuccessfully { get { return UserGuess != null && UserGuess.Equals(CorrectAnswer); } }
        Answer UserGuess { get; set; }
       
    }
    
    class Answer 
    {
       string text { get; set; }
    }
    class Game
    {
        public Game()
        {
             Questions = new ObservableCollection<Question>();
             for (int i = 0; i < 10; i++) { Questions.Add(GenerateQuestion()); }
        }
        public Question GenerateQuestion()
        {
           Question q = new Question();
           q.ImageURI = your link to image//;
           q.Text = your image text//;
           q.Answers = new ObservableCollection<Answer>();
           q.CorrectAnswer = the correct answer//;
           q.Answers.Add(CorrectAnswer);
    
           for (int i = 0; i < 5; i++) { q.Answers.Add(GenerateAnswer(q.CorrectAnswer)); }
    
           return q;
        }
       public Answer GenerateAnswer(Answer ignore) 
    {
         List<Answer> answers = DataStore.Answers;//go to your main list of answers.
    
         Random rand = new Random();
    
         Answer a = answers[Random.Next(0,answers.Size())];
         while (a == null || a.Equals(ignore) {  a = answers[Random.Next(0,answers.Size())];}
         return a;
    }
        public ObservableCollection<Question> Questions { get; set; }    
    }
