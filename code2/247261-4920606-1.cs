    public class QuizItem
    {
        public int QuizItemId { get; set; }
        public string Question { get; set; }
        private IEnumerable<Choice> choices;
        public IEnumerable<Choice> Choices
        {
            get { return choices; }
        }
        public void SetChoices(IEnumerable<Choice> choices)
        {
            foreach (var x in choices)
                x.QuizItem = this;
            this.choices = choices;                
        }
    }
