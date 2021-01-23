    public class MultipleChoiceQuestion
    {
        private readonly List<Option> options
            = new List<Option>();
        public IList<Option> Options {get { return options; } }
    }
    public class Option
    {
        public MultipleChoiceQuestion Question {get;set;}
    }
