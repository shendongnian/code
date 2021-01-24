    public class TransactionalAttribute : Attribute, IActionFilter
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
