    public class QueryHandler
    {
        private readonly IDataAccessAdapterProvider _dataAccessAdapterProvider;
        private readonly IWrap _wrap; //I'm assuming you'll want a different name.
        public QueryHandler(IDataAccessAdapterProvider provider, IWrap wrap)
        {
            _dataAccessAdapterProvider = provider;
            _wrap = wrap;
        }
