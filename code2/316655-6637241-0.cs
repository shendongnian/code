    				mm.From = new MailAddress("noreply@mail.com");
    
    				SmtpClient client = new SmtpClient("127.0.0.1");
    
    				string smtpServerUserName = "username";
    				string smtpServerPassword = "password"; 
   				if (smtpServerUserName.HasValue() && smtpServerPassword.HasValue())
    				{
    					client.Credentials = new NetworkCredential(smtpServerUserName, smtpServerPassword);
    				}
    				smtpServerPort = "";
    				if (smtpServerPort.HasValue())
    				{
    					client.Port = Convert.ToInt32(smtpServerPort, CultureInfo.InvariantCulture);
    				}
    				mm.Priority = MailPriority.Normal;
    
    				mm.IsBodyHtml = false;
    
    				mm.Subject = subject;
    				mm.To.Add(new MailAddress("you@home.com"));
    				mm.Body = body;
    
    				client.Send(mm);
    			}
    		}
