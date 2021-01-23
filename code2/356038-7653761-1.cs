    public class UnitOfWork : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;
     
        public UnitOfWork(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
     
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _unitOfWork.Begin();
        }
     
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                    {
                        try
                        {
                            _unitOfWork.Commit();
                        }
                        catch(Exception ex)
                        {
                            _unitOfWork.Rollback();
                            throw new InvalidOperationException("Exception during commit",ex);
                        }
                    }
                    else
                    {
                        _unitOfWork.Rollback();
                    }
        }
    }
    ...
    ...
    //meanwhile.. in the controler
    [UnitOfWork]
    public ActionResult SomeAction(int id)
    {
    //do some stuff with your injected services
    }
