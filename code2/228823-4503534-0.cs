    protected override void OnException(ExceptionContext filterContext)
        {
          //Build of error source.
          string askerUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
          Exception exToLog = filterContext.Exception;
          exToLog.Source = string.Format("Source : {0} {1}Requested Path : {2} {1}", exToLog.Source, Environment.NewLine, askerUrl);
          //Log the error
          ExceptionLogger.Publish(exToLog, "unhandled", filterContext.RequestContext.HttpContext.Request.ServerVariables.ToString(), askerUrl);
          //Redirect to error page : you must feed filterContext.Result to cancel already executing Action
          filterContext.ExceptionHandled = true;
          filterContext.Result = new ErrorController().ManageError(ErrorResources.GeneralErrorPageTitle, ErrorResources.GeneralErrorTitle, ErrorResources.GeneralErrorInnerBody, exToLog);
          base.OnException(filterContext);
        }
