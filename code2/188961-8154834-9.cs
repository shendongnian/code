    namespace WebHackery
    {
      public class AjaxServiceHandler : IHttpHandler
      {
        private readonly Type _restHandlerType;
        private readonly MethodInfo _createHandler;
        private readonly MethodInfo _getRawParams;
        private readonly MethodInfo _invokeMethod;
        private readonly MethodInfo _writeExceptionJsonString;
        private readonly FieldInfo _webServiceMethodData;
        
        public AjaxServiceHandler()
        {
          _restHandlerType = typeof(ScriptMethodAttribute).Assembly.GetType("System.Web.Script.Services.RestHandler");
    
          _createHandler = _restHandlerType.GetMethod("CreateHandler", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(HttpContext) }, null);
          _getRawParams = _restHandlerType.GetMethod("GetRawParams", BindingFlags.NonPublic | BindingFlags.Static);
          _invokeMethod = _restHandlerType.GetMethod("InvokeMethod", BindingFlags.NonPublic | BindingFlags.Static);
          _writeExceptionJsonString = _restHandlerType.GetMethod("WriteExceptionJsonString", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(HttpContext), typeof(Exception) }, null);
    
          _webServiceMethodData = _restHandlerType.GetField("_webServiceMethodData", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
        }
    
        public bool IsReusable
        {
          get { return true; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
          var restHandler = _createHandler.Invoke(null, new Object[] { context });
          var methodData = _webServiceMethodData.GetValue(restHandler);
          var rawParams = _getRawParams.Invoke(null, new[] { methodData, context });
    
          try
          {
            _invokeMethod.Invoke(null, new[] { context, methodData, rawParams });
          }
          catch (Exception ex)
          {
            while (ex is TargetInvocationException)
              ex = ex.InnerException;
    
            // Insert Custom Error Handling HERE...
            _writeExceptionJsonString.Invoke(null, new Object[] { context, ex});
          }
        }
      }
    }
