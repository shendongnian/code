    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<AnimalAsnwer> animals = new List<AnimalAsnwer>() {
                    new AnimalAsnwer() { Value = 3, QuestionId = "howbig"},
                    new AnimalAsnwer() { Value = 5, QuestionId = "howold"},
                    new AnimalAsnwer() { Value = 9, QuestionId = "howbig" },
                    new AnimalAsnwer() { Value = 2, QuestionId = "howold" },
                    new AnimalAsnwer() { Value = 10, QuestionId = "howmanyvacationdays" }
                };
                var summary = animals.GroupBy(x => x.QuestionId)
                    .Select(x => new { question = x.Key, values = x.Select(y => y.Value).ToList() }).ToList();
            }
        }
        public class AnimalAsnwer
        {
            public string QuestionId { get; set; }
            public int Value { get; set; }
        } 
    }
