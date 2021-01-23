     protected override OnActionExecuted(ActionExecutedContext context)
     {
          ViewResult viewResult = filterContext.Result as ViewResult;
          if(viewResult != null)
          {
               MyDomainModel model = viewResult.ViewData.Model as MyDomainModel;
 
               if(model != null)
                  /* Set Properties on your Model, for any model deriving 
                     from MyDomainModel! */
          }
     } 
