    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class TransactionAttribute : ActionFilterAttribute
    {
        private ITransaction Transaction { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Transaction = MvcApplication.CurrentSession.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!Transaction.IsActive)
                return;
            if (filterContext.Exception == null)
            {
                Transaction.Commit();
                return;
            }
            Transaction.Rollback();
        }
    }
