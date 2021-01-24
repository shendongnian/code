    [Serializable]
    public class Question
    {
        public string text;
        public string correct;
        public string answer1;
        public string answer2;
        public string answer3;
    }
    [Serializable]
    public class RootObject
    {
        public List<Question> question;
    }
