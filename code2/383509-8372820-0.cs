    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
    
       if (controllerType == null)
          return new DumbController();
    
       return base.GetControllerInstance(requestContext, controllerType);
    }
    
    class DumbController : Controller {
    
       protected override void HandleUnknownAction(string actionName) {
    
          try {
             View(actionName).ExecuteResult(this.ControllerContext);
          } catch (Exception ex) {
             throw new HttpException(404, "Not Found", ex);
          }
       }
    }
