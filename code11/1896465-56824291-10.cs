    public class MyAppRepository : IMyAppRepository
    {
		private readonly IMyAppContext _context;
	
        public MyAppRepository(IMyAppContext context)
        {
            _context = context;
        }
        public int AddQuestion(Question question)
        {
            return _context.Insert(question);
        }
        ...
    }
