    public interface IPool
    {
        void Execute();
    }
    
    public class Pool : IPool
    {
        private Pool() { }
    
        public IPickListGenerator PickListGenerator { set; private get; }
        public IQuestionIsAnswerableDeterminer IsQuestionIsAnswerableDeterminer { set; private get; }
    
        public static IPool GetSportsGame() 
        {
            return new Pool
            {
                PickListGenerator = new SportsPicklistGenerator(),
                IsQuestionIsAnswerableDeterminer = new GameQuestionIsAnswerableDeterminer()
            };
        }
        public static IPool GetSportsEntertainment() 
        {
            return new Pool
            {
                PickListGenerator = new SportsPicklistGenerator(),
                IsQuestionIsAnswerableDeterminer = new EntertainmentPicklistGenerator()
            };
        }
        public void Execute()
        {
            IsQuestionIsAnswerableDeterminer.Execute();
            PickListGenerator.Execute();
        }
    }
