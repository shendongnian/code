    public override void ExecuteResult(ActionContext context)
    {
        // snip boilerplate code
        context.HttpContext.Response.StatusCode = StatusCode;
    }
