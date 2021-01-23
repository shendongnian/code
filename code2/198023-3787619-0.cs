    public class QuestionExtended : Question
    {
        public QuestionExtended(IEnumerable<Option> options) : base()
        {
            OptionList = new List<Option>(options);
        }
    
        public List<Option> OptionList { get; private set;}
    }
