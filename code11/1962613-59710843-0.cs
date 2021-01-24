    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result.GetType().Equals(typeof(Microsoft.AspNetCore.Mvc.ObjectResult)))
        {
            var res = ((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result).Value;
    
            if (res.GetType().Equals(typeof(CartResponse)))
            {
                CartResponse response = res as CartResponse;
            }
        }
    }
