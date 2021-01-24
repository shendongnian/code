    public class SaveMyQueryData : IQueryHandler<Q, R>
    {
        private readonly IQueryHandler<Q, R> _queryHandler;
        private readonly IProductRepository _productRepository;
    
        public SaveMyQueryData(
            IQueryHandler<Q, R> queryHandler,
            IProductRepository productRepository)
        {
            _queryHandler = queryHandler;
            _productRepository = productRepository;
        }
    
        public Q Handle(Q query)
        {
            var result = _queryHandler.Handle(query);
            var view = result as View<SingleView>; 
    
            // do something with view
    
            return result;
        }
    }
