    public override void OnPageHandlerExecuting(PageHandlerSelectedContext context)
    {
        if(context.HandlerMethod.MethodInfo.Name == nameof(OnGet))
        {
            // code placed here will only execute if the OnGet() method has been selected
        }
    }
