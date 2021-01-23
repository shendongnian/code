    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class UnitOfWorkAction : Attribute
        {
        }
    
        public class UnitOfWorkActionFilter : IActionFilter
        {
            private IUnitOfWork _unitOfWork;
    
            public UnitOfWorkActionFilter(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
    
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                _unitOfWork.Begin();
            }
    
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.Exception == null)
                    {
                        try
                        {
                            _unitOfWork.Commit();
                        }
                        catch
                        {
                            _unitOfWork.Rollback();
                            throw;
                        }
                    }
                    else
                    {
                        _unitOfWork.Rollback();
                    }
            }
        }
