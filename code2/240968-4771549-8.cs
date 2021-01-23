        public class Pool
        {
            public IPickListGenerator PickListGenerator { set; private get; }
            public IQuestionIsAnswerableDeterminer IsQuestionIsAnswerableDeterminer { set; private get; }
    
            public void Execute()
            {
                IsQuestionIsAnswerableDeterminer.Execute();
                PickListGenerator.Execute();
            }
        }
