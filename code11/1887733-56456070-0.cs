    public class AddPaginationHeader : IResultFilter
    {
        private readonly IRepository repository;
        
        // inject services
        public AddPaginationHeader(IRepository repository, ... other services)
        {
            this.repository = repository;
        }
        public void IResultFilter.OnResultExecuting(ResultExecutingContext context)
        {
            ...
        }
        public void IResultFilter.OnResultExecuted(ResultExecutedContext context) { ... }
    }
