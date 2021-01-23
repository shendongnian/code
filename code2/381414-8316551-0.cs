    public class StackoverflowService
    {
        private StackoverflowDbContext _container;
    
        public StackoverflowService(StackoverflowDbContext container)
        {
            _container = container;
        }
    
        public IEnumerable<Question> GetRecentQuestions() 
        { 
             var model = _container.Questions.OrderByDescending(x => x.Posted);
             return model.Take(20);
        } 
        
        public void PostAnswer(Question question, Answer answer) { ... }
    }
    
