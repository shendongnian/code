    [Serializable]
    public class QuizData
    {
        public int status;
        public string email;
        public Question[] questions;
    }
    
    [Serializable]
    public class Question
    {
        public string A;
        public string C;
        public string B;
        public string D;
        public string question;
        public string your_amswer;
        public int points;
        public string correct_answer;
    }
    
