    public class JsonDotNetResult : ActionResult
    {
        private object _obj { get; set; }
        public JsonDotNetResult(object obj)
        {
            _obj = obj;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AddHeader("content-type", "application/json");
            context.HttpContext.Response.Write(JsonConvert.SerializeObject(_obj));
        }
    }
