                SmtpClient smtpClient = new SmtpClient(smtpServerName);                          
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpUName, smtpUNamePwd);
                smtpClient.Credentials = credentials;
                smtpClient.UseDefaultCredentials = false;  <-- Set This Line After Credentials
                smtpClient.Send(mailMsg);
                smtpClient = null;
                mailMsg.Dispose();
