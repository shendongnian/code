    protected override void OnResultExecuting(ResultExecutingContext ctx) {
        base.OnResultExecuting(ctx);
        var baseView = ctx.Result as BaseViewModel;
        if (baseView != null)
        {
            //assign values here
        }
    }
