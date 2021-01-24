    public class SqLiteAbcdRepository : IAbcdRepository
    {
		private readonly IAbcdContext _context;
	
        public SqLiteMyAppRepository(IAbcdContext context)
        {
            _context = context;
        }
        public int AddQuestion(Question question)
        {
            return _context.Insert(question);
        }
        public int UpdateQuestion(Question question)
        {
            return _context.Update(question);
        }
        ...
    }
