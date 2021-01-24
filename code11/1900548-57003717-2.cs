    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<AnimalAsnwer> animals = new List<AnimalAsnwer>() {
                    new AnimalAsnwer() { index = 1, Value = 3, QuestionId = "howbig"},
                    new AnimalAsnwer() { index = 2, Value = 5, QuestionId = "howold"},
                    new AnimalAsnwer() { index = 3, Value = 9, QuestionId = "howbig" },
                    new AnimalAsnwer() { index = 4, Value = 2, QuestionId = "howold" },
                    new AnimalAsnwer() { index = 5, Value = 10, QuestionId = "howmanyvacationdays" }
                };
                var summary = animals.GroupBy(x => x.QuestionId)
                    .Select(x => new { question = x.Key, values = x.Select(y => new { value = y.Value, index = y.index }).ToList() }).ToList();
            }
        }
        public class AnimalAsnwer
        {
            public string QuestionId { get; set; }
            public int Value { get; set; }
            public int index { get; set; }
        } 
    }
