    public class MyAppHost : MarshalByRefObject
    {
        public string RenderHomeIndexAction()
        {
            var controller = new HomeController();
            using (var writer = new StringWriter())
            {
                var httpContext = new HttpContext(new HttpRequest("", "http://example.com", ""), new HttpResponse(writer));
                if (HttpContext.Current != null) throw new NotSupportedException("httpcontext was already set");
                HttpContext.Current = httpContext;
                var controllerName = controller.GetType().Name;
                var routeData = new RouteData();
                routeData.Values.Add("controller", controllerName.Remove(controllerName.LastIndexOf("Controller")));
                routeData.Values.Add("action", "index");
                var controllerContext = new ControllerContext(new HttpContextWrapper(httpContext), routeData, controller);
                var res = controller.Index();
                res.ExecuteResult(controllerContext);
                HttpContext.Current = null;
                return writer.ToString();
            }
        }
    }
