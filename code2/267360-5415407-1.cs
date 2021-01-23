    Main()
    {
        SmtpClient MyClient = new SmtpClient(args[0]);
                    
        // define to, from and message body
    
        MyClient.SendCompleted += new 
        
        SendCompletedEventHandler(SendCompletedCallback);
    
        client.SendAsync(message, userState);
        message.Dispose();
         
      
    }
    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
         static bool MailStatus= false;
                    
         if (e.Error != null)
         {
              Console.WriteLine("{1}", e.Error.ToString());
         }
         else
         {
             Console.WriteLine("Message sent.");
         }
         
         MailStatus = true;
    }
                
