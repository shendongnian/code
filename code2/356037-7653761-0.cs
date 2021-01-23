    public class UnitOfWork : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;
        private ILogger _logger;
     
        public UnitOfWork(IUnitOfWork unitOfWork,ILogger logger)
        {
            _unitOfWork=unitOfWork;
            _logger = logger;
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
                        catch (Exception ex)
                        {
                            _logger.Error("Exception Occured while commiting unit of work", ex);
                            _unitOfWork.Rollback();
                        }
                    }
                    else
                    {
                        try
                        {
                            _unitOfWork.Rollback();
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Exception Occured while rolling back unit of work", ex);
                        }
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
