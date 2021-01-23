    public class ViewOrAjaxResult : ActionResult
    {
        private readonly ViewResult _viewResult;
        private readonly ActionResult _ajaxActionResult;
        public ViewOrAjaxResult(ViewResult viewResult, ActionResult ajaxActionResult)
        {
            _viewResult = viewResult;
            _ajaxActionResult = ajaxActionResult;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var isAjaxRequest = context.HttpContext.Request["isAjax"];
            if (isAjaxRequest != null && isAjaxRequest.ToLower() == "true")
            {
                _ajaxActionResult.ExecuteResult(context);    
            } else
            {
                _viewResult.ExecuteResult(context);
            }
        }
    }
