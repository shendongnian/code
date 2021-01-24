    public override void OnException(MethodExecutionArgs args)
    {
        var methType = ((MethodInfo)args.Method).ReturnType;
        
        args.ReturnValue = Activator.CreateInstance(methType, ((ControllerBase)args.Instance).BadRequest());
        args.FlowBehavior = FlowBehavior.Return;
    }
