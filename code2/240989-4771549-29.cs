    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Example usages:
                var pool = new Pool
                {
                    PickListGenerator = new SportsPicklistGenerator(),
                    IsQuestionIsAnswerableDeterminer = new GameQuestionIsAnswerableDeterminer()
                };
                pool.ExecuteIsQuestionIsAnswerableDeterminer();
                pool.ExecutePickListGenerator();
            }
        }
    
        public class Pool
        {
            public IPickListGenerator PickListGenerator { set; private get; }
            public IQuestionIsAnswerableDeterminer
                IsQuestionIsAnswerableDeterminer { set; private get; }
    
            public void ExecuteIsQuestionIsAnswerableDeterminer()
            {
                IsQuestionIsAnswerableDeterminer.Execute();
            }
    
            public void ExecutePickListGenerator()
            {
                PickListGenerator.Execute();
            }
        }
    }
