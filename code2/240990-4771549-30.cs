        public class Pool
        {
            public IPickListGenerator PickListGenerator { set; private get; }
            public IQuestionIsAnswerableDeterminer 
                IsQuestionIsAnswerableDeterminer { set; private get; }
    
            public void Execute()
            {
                // improvements, seen by Arnis
                if (IsQuestionIsAnswerableDeterminer == null)
                {
                    thrown new ArgumentException("IsQuestionIsAnswerableDeterminer");
                }
                if (PickListGenerator == null)
                {
                    thrown new ArgumentException("PickListGenerator");
                }
                IsQuestionIsAnswerableDeterminer.Execute();
                PickListGenerator.Execute();
            }
        }
