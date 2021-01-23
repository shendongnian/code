    public class Questionary
    {
        private Lazy<List<Question>> _questions = 
            new Lazy<List<Question>>(() => new List<Question>());
    
        public IList<Question> Questions { get { return _questions.Value; } }
    }
