    //filter factory is used in order to create new filter instance per request
    public class TransactionalAttribute : Attribute, IFilterFactory
    {
        //make sure filter marked as not reusable
        public bool IsReusable => false;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new TransactionalFilter();
        }
        private class TransactionalFilter : IActionFilter
        {
            private TransactionScope _transactionScope;
            public void OnActionExecuting(ActionExecutingContext context)
            {
                _transactionScope = new TransactionScope();
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                //if no exception were thrown
                if (context.Exception == null)
                    _transactionScope.Complete();
            }
        }
    }
