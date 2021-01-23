        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result !=null && 
                (filterContext.Result.GetType() == typeof(HttpNotFoundResult) )
            {
                //You can transfer to a known route for example
                filterContext.Result = new TransferResult(SomeAction, SomeController);
            }
        }
