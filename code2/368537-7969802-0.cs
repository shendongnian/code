    public class Handler : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
                 String notificationMessage = "Email body.";
                 Mailer.SendMail("targetemail@gmail.com", "Email header", notificationMessage);
    	}
    }
