    public enum AnswerOption
    {
        None,
        A,
        B,
        C,
        D
    }
    [Serializable]
    public class Question
    {
        public string A;
        public string C;
        public string B;
        public string D;
    
        public string question;
        public AnswerOption your_amswer;
        public int points;
        public AnswerOption correct_answer;
    }
