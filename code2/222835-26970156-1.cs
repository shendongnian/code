    	public class CustomSmtpClient
    	{
    		private readonly SmtpClient _smtpClient;
    
    		public CustomSmtpClient(string sectionName = "default")
    		{
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("mailSettings/" + sectionName);
    
                _smtpClient = new SmtpClient();
    
                if (section != null)
                {
                    if (section.Network != null)
                    {
                        _smtpClient.Host = section.Network.Host;
                        _smtpClient.Port = section.Network.Port;
                        _smtpClient.UseDefaultCredentials = section.Network.DefaultCredentials;
    
                        _smtpClient.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password, section.Network.ClientDomain);
                        _smtpClient.EnableSsl = section.Network.EnableSsl;
    
                        if (section.Network.TargetName != null)
                            _smtpClient.TargetName = section.Network.TargetName;
                    }
    
                    _smtpClient.DeliveryMethod = section.DeliveryMethod;
                    if (section.SpecifiedPickupDirectory != null && section.SpecifiedPickupDirectory.PickupDirectoryLocation != null)
                        _smtpClient.PickupDirectoryLocation = section.SpecifiedPickupDirectory.PickupDirectoryLocation;
                }
    		}
    
    		public void Send(MailMessage message)
    		{
    			_smtpClient.Send(message);
    		}
    }
