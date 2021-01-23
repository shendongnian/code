    public CapturedViewResult Capture(ControllerContext controllerContext, Func<ActionResult> action)
		{
			CapturedViewResult capturedViewResult = new CapturedViewResult();
			HttpContext currentContext = HttpContext.Current;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				HttpResponse response = new HttpResponse(stringWriter);
				HttpContext context = new HttpContext(currentContext.Request, response) { User = currentContext.User };
				context.Items["LocalizationContext"] = currentContext.Items["LocalizationContext"];
				HttpContext.Current = context;
				ViewResult result = action.Invoke() as ViewResult;
				if (result != null)
				{
					capturedViewResult.ViewName = result.ViewName;
					result.ExecuteResult(controllerContext);
				}
				else
				{
					throw new ArgumentException("Supplied controller action method did not return a ViewResult", "action");
				}
				HttpContext.Current = currentContext;
				capturedViewResult.CapturedHtml = stringWriter.ToString();
			}
			return capturedViewResult;
		}
