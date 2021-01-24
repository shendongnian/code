    public class CustomExceptionAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //Check the type of exception. If its related to model binding,
            //then your logic as what needs to be done
        }
    }
