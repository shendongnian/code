    public class JsonDotNetResult : ActionResult
    {
        public JsonDotNetResult(object data)
        {
            Data = data;
        }
        
        //Name the property Data and make the getter public
        public object Data { get; private set; }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AddHeader("content-type", "application/json");
            context.HttpContext.Response.Write(JsonConvert.SerializeObject(Data));
        }
    }
