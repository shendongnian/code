    public override void OnException(MethodExecutionArgs args)
    {
        args.FlowBehavior = FlowBehavior.Return;
        args.YieldValue = ((ControllerBase)args.Instance).BadRequest();
    }
