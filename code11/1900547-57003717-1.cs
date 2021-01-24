    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<AnimalAnswer> animals = new List<AnimalAnswer>() {
                    new AnimalAnswer() { Value = 3, QuestionId = "howbig"},
                    new AnimalAnswer() { Value = 5, QuestionId = "howold"},
                    new AnimalAnswer() { Value = 9, QuestionId = "howbig" },
                    new AnimalAnswer() { Value = 2, QuestionId = "howold" },
                    new AnimalAnswer() { Value = 10, QuestionId = "howmanyvacationdays" }
                };
                var summary = animals.GroupBy(x => x.QuestionId)
                    .Select(x => new { question = x.Key, values = x.Select(y => y.Value).ToList() }).ToList();
            }
        }
        public class AnimalAnswer
        {
            public string QuestionId { get; set; }
            public int Value { get; set; }
        } 
    }
