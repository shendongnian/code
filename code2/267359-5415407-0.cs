    protected void YourMethod()
    { 
           SmtpClient myClient = new SmtpClient();
            
           // use MailAddress and define everything
            try
            {  
                myClient.send(//args);
            }     
            catch(Exception ex)
            {
                Response.Write(e.Message);
            }
    }
    
