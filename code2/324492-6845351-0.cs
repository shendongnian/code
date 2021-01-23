    public class Questionary
    {
        private Lazy<IList<Question>> _questions = 
            new Lazy<IList<Question>>(() => new List<Question>());
    
        public IList<Question> Questions
        {
            get { return _questions.Value; }
            set { _questions = new Lazy<IList<Question>>(() => value); }
        }
    }
