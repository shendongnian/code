    public class MyAppRepository : IMyAppRepository
    {
		private readonly IAbcdContext _context;
	
        public MyAppRepository(IAbcdContext context)
        {
            _context = context;
        }
        public int AddQuestion(Question question)
        {
            return _context.Insert(question);
        }
        ...
    }
