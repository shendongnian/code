        public interface IPickListGenerator
        {
            void Execute();
        }
    
        public interface IQuestionIsAnswerableDeterminer
        {
            void Execute();
        }
        public class SportsPicklistGenerator : IPickListGenerator
        {
            public void Execute()
            {
                // Do something
            }
        }
    
        public class EntertainmentPicklistGenerator : IPickListGenerator
        {
            public void Execute()
            {
                // Do something
            }
        }
       
        public class GameQuestionIsAnswerableDeterminer : IQuestionIsAnswerableDeterminer
        {
            public void Execute()
            {
                // Do something
            }
        }
    
        public class RoundQuestionIsAnswerableDeterminer : IQuestionIsAnswerableDeterminer
        {
            public void Execute()
            {
                // Do something
            }
        }
