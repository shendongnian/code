     try
     {
         smtpClient.Send(mailMsg);
     }
     catch (Exception ex)
     {
         Console.WriteLine(ex);   //Should print stacktrace + details of inner exception
         if (ex.InnerException != null)
         {
             Console.WriteLine("InnerException is: {0}",ex.InnerException);
         }
     }
