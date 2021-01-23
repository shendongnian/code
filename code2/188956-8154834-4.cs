    internal static void ExecuteWebServiceCall(HttpContext context, WebServiceMethodData methodData)
    {
        try
        {
            NamedPermissionSet namedPermissionSet = HttpRuntime.NamedPermissionSet;
            if (namedPermissionSet != null)
            {
                namedPermissionSet.PermitOnly();
            }
            IDictionary<string, object> rawParams = GetRawParams(methodData, context);
            InvokeMethod(context, methodData, rawParams);
        }
        catch (Exception exception)
        {
            WriteExceptionJsonString(context, exception);
        }
    }
