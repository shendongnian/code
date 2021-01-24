    public class QuestionStructure
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string PossibleAnswear { get; set; }
    }
    public class ViewModel
    {
        public List<QuestionStructure> Questions { get; set; }
        public ViewModel()
        {
            QuestionStructure q1 = new QuestionStructure
            {
                Id = 1,
                Question = "How many days in a leap year?",
                PossibleAnswear = "2356,366,212,365"
            };
            QuestionStructure q2 = new QuestionStructure
            {
                Id = 2,
                Question = "What is the next number in the series 2, 3, 5, 7, 11...?",
                PossibleAnswear = "15,88,99,13"
            };
            QuestionStructure q3 = new QuestionStructure
            {
                Id = 3,
                Question = "How many wheel has a bike got?",
                PossibleAnswear = "5,3,4,2"
            };
            QuestionStructure q4 = new QuestionStructure
            {
                Id = 4,
                Question = "How many fingers have you got?",
                PossibleAnswear = "5,8,20,10"
            };
            List<QuestionStructure> items = new List<QuestionStructure>();
            items.Add(q1);
            items.Add(q2);
            items.Add(q3);
            items.Add(q4);
            this.Questions = items;
        }
    }
