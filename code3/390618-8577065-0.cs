    public class AjaxableResult : ActionResult
    {
      private readonly JsonResult _jsonResult;
      private readonly PartialViewResult _partialViewResult;
      public AjaxableResult(JsonResult jsonResult, PartialViewResult partialViewResult)
      {
        _jsonResult = jsonResult;
        _partialViewResult = _partialViewResult;
      }      
      public override void ExecuteResult(ControllerContext context)
      {
        if (context.HttpContext.Request.IsAjaxRequest()) {
          _jsonResult.ExecuteResult(context);
        }
        else
        {
          _partialViewResult.ExecuteResult(context);
        }
      }
    }
