    public class StatusResolver : IValueResolver<SourceObject, DestinationObject, DestinationStatus>
    {
        private readonly MyContext _context;
        public StatusResolver(MyContext context)
        {
            _context = context;
        }
	    public DestinationStatus Resolve(SourceObject source, DestinationObject destination, int member, ResolutionContext context)
    	{
            return _context.DestinationStatuses.Find(source.StatusId);
    	}
    }
