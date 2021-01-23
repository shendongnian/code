    public override void ExecuteResult(ControllerContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (string.IsNullOrEmpty(this.ViewName))
        {
            this.ViewName = context.RouteData.GetRequiredString("action");
        }
        ViewEngineResult result = null;
        if (this.View == null)
        {
            result = this.FindView(context);
            this.View = result.View;
        }
        TextWriter output = context.HttpContext.Response.Output;
        ViewContext viewContext = new ViewContext(context, this.View, this.ViewData, this.TempData, output);
        this.View.Render(viewContext, output);
        if (result != null)
        {
            result.ViewEngine.ReleaseView(context, this.View);
        }
    }
