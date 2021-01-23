        try
        {
            MailMessage m = new MailMessage("WindowsLiveUserName@live.com", "myEmail@gmail.com", "Situação", "Oi, tudo bem?");
            SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
	    smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;            
            smtp.Credentials = new NetworkCredential("WindowsLiveUserName@live.com", "YourPassword", "");
            
            smtp.Send(m);
            Console.WriteLine("sucesso");
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.ReadKey();
        }
