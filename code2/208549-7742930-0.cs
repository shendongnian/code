            public void ProcessRequest(HttpContext context)
        {
            string soapAction = context.Request.Headers["SOAPAction"];
            context.Request.Headers.Set("SOAPAction", soapAction.Replace("OLD_NAMESPACE", "NEW_NAMESPACE"));
            WebServiceHandlerFactory factory = new WebServiceHandlerFactory();
            IHttpHandler handler = factory.GetHandler(context, context.Request.HttpMethod, context.Request.FilePath, context.Request.PhysicalPath);
            handler.ProcessRequest(context);
            context.Request.Headers.Set("SOAPAction", soapAction);
            context.ApplicationInstance.CompleteRequest();
        }
