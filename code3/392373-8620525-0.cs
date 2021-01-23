    public class JsonpResult: ActionResult
    {
        public readonly object _model;
        public readonly string _callback;
        public JsonpResult(object model, string callback)
        {
            _model = model;
            _callback = callback;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var js = new JavaScriptSerializer();
            var jsonp = string.Format(
                "{0}({1})", 
                _callback, 
                js.Serialize(_model)
            );
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(jsonp);
        }
    }
