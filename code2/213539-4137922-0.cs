    public void Send()
    {
        if(string.IsNullOrEmpty(this.Server))
        {
            throw new PreferenceNotSetException("Server not set");
        }
        if(string.IsNullOrEmpty(this.From))
        {
            throw new PreferenceNotSetException("E-Mail address not set.");
        }
        
        if(string.IsNullOrEmpty(this.To))
        {
            throw new PreferenceNotSetException("Recipients E-Mail address not set.");
        }
        
        using(System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(this.From, this.To, this.Subject, this.FormattedText))
                    { 
                       message.IsBodyHtml = true;
                        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(this.Server);
                        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        try 
                        {
                            client.Send(message);
                        }  
                        catch(System.Exception ex) 
                        {
                            //Put this in for debugging only.
                            System.Windows.Forms.MessageBox.Show(ex.ToString());              
                        }
        }
    }
