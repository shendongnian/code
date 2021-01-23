    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var modelstate = context.ModelState;
        var keys = modelstate.Keys.Where(x => ExculdeFeilds.Split(",").ToList().Contains(x));
        foreach (var item in keys)
        {
            modelstate[item].ValidationState = ModelValidationState.Valid;
        }
        if (!modelstate.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
