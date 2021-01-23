    public class SendEmailAttribute : ActionFilterAttribute
     {
       
        public SendEmailAttribute()
        {
            //Initialize logic --Dependency injection
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            SendMail(context); //Implement email sending logic using MailMessage
        }
     }
