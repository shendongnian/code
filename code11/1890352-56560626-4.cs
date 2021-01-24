    [Serializable]
    public class Question : ISerializationCallbackReceiver
    {
        public readonly Dictionary<AnswerOption, string>() answers;
        public string A;
        public string C;
        public string B;
        public string D;
    
        public string question;
        public AnswerOption your_amswer;
        public int points;
        public AnswerOption correct_answer;
        public void OnBeforeSerialize()
        {
            // do nothing but required by the interface
        }
        public void OnAfterDeserialize()
        {
            answers = new Dictionary<AnswerOption, string>(4);
            _myDictionary.Add(AnswerOption.A, A);
            _myDictionary.Add(AnswerOption.B, B);
            _myDictionary.Add(AnswerOption.C, C);
            _myDictionary.Add(AnswerOption.D, D);
        }
    }
