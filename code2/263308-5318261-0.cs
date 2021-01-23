    SmtpClient smtp = new SmtpClient();
    			smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
    			smtp.Send(msgMail);
    
    void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    	{
    		if (e.Cancelled == true || e.Error != null)
    		{
    			throw new Exception(e.Cancelled ? "EMail sedning was canceled." : "Error: " + e.Error.ToString());
    		}
