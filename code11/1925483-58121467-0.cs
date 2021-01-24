    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (ControllerModel controller in context.Result.Controllers)
        {
            foreach (ActionModel action in controller.Actions)
            {
                var verbs = action.Attributes.OfType<HttpMethodAttribute>().SelectMany(x => x.HttpMethods).Distinct();
    
                foreach (var verbItem in verbs)
                {
                    Console.WriteLine(verbItem);
                }
            }
        }
    }
