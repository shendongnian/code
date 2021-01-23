     public CapturedViewResult Capture(ControllerContext controllerContext, Func<ActionResult> action)
        {
            var capturedViewResult = new CapturedViewResult();
            var currentContext = HttpContext.Current;
            using (var stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                var response = new HttpResponse(stringWriter);
                var context = new HttpContext(currentContext.Request, response) { User = currentContext.User };
                foreach (var key in currentContext.Items.Keys)
                {
                    context.Items.Add(key, currentContext.Items[key]);
                }
                HttpContext.Current = context;
                var result = action.Invoke() as ViewResult;
                if (result != null)
                {
                    capturedViewResult.ViewName = result.ViewName;
                    result.ExecuteResult(controllerContext);
                }
                else
                {
                    throw new ArgumentException("Supplied controller action method did not return a ViewResult", "action");
                }
                foreach (var key in context.Items.Keys)
                {
                    currentContext.Items[key] = context.Items[key];
                }
                HttpContext.Current = currentContext;
                capturedViewResult.CapturedHtml = stringWriter.ToString();
            }
            return capturedViewResult;
        }
