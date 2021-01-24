      class Program
        {
            public class Question
            {
                public ulong Channel { get; set; }
    
                public ulong User { get; set; }
    
                public Object Answer { get; set; }
            }
    
            static void Main(string[] args)
            {
                var questions = new List<Question>
                {
                    new Question
                    {
                        Channel = 1,
                        User = 1,
                        Answer = 1
                    },
                    new Question
                    {
                        Channel = 2,
                        User = 2,
                        Answer = 2
                    },
                    new Question
                    {
                        Channel = 3,
                        User = 3,
                        Answer = 3
                    },
                };
    
                foreach (var question in questions)
                {
                    Console.WriteLine(question.Answer);
                }
    
                var channel3Index = questions.FindIndex((obj) => obj.Channel == 3);
                if (channel3Index > -1)
                {
                    questions[channel3Index].Answer = 666;
                }
    
                foreach (var question in questions)
                {
                    Console.WriteLine(question.Answer);
                }
    
                Console.ReadKey();
            }
        }
