    public class Questionary
    {
        private IList<Question> _questions = new List<Question>();
    
        public IList<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
