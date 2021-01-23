    public static class ContollerExtensions
    {
        public static JsonpResult Jsonp(this Controller controller, object data)
        {
            JsonpResult result = new JsonpResult();
            result.Data = data;
            //result.ExecuteResult(controller.ControllerContext); <-- Remove this !!!
            return result;
        }
    }
