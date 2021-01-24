    //handles only exceptions caused by dividing by zero
    public class DivideByZeroExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //chech if this is divide by zero exception
            if (!(context.Exception is DivideByZeroException))
                return;
            var myerror = new
            {
                result = false,
                message = "Division by zero went wrong"
            };
            context.Result = new ObjectResult(myerror)
            {
                StatusCode = 500
            };
            //set "handled" to true since exception is already property handled
            //and there is no need to run other filters
            context.ExceptionHandled = true;
        }
    }
