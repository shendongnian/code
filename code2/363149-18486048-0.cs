    try
            {
                string txtBody = "";
                string emailUser = ConfigurationManager.AppSettings["MailAuthUser"];
                string emailPass = ConfigurationManager.AppSettings["MailAuthPass"];
                string mailServer = ConfigurationManager.AppSettings["MailServer"];
                
                txtBody = "<b>" + ("موضوع:" + "  " + emailmod.Subject + "</b>" + "<br/><br/><b>" + "ارسال کننده: </b>" + emailmod.SenderEmail + "<br/><br/><b>" + "پیام: </b>" + emailmod.Message + "<br/><br/>" + emailmod.PagePath);
                
                ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
                ExchangeService exservice = new ExchangeService();
                AutodiscoverService auservice = new AutodiscoverService(mailServer);
                if (auservice.ServerInfo != null)
                {
                    try
                    {
                        exservice.AutodiscoverUrl(emailUser);
                    }
                    catch (AutodiscoverRemoteException ex)
                    {
                        //Console.WriteLine("Exception thrown: " + ex.Error.Message);
                    }
                }
                else
                {
                    exservice.Url = new Uri("https://" + "outlook.apornak.com" + "/EWS/Exchange.asmx");
                }
                exservice.UseDefaultCredentials = true;
                
                if (exservice.ServerInfo == null)
                {
                    exservice.Credentials = new WebCredentials(emailUser, emailPass);
                }
                EmailMessage message = new EmailMessage(exservice);
                message.Subject = "اعلام ایرادات و پیشنهادات";
                message.Body = Resources.Message.AdvMailTemplate.Replace("#$Body$#", txtBody);
                message.ToRecipients.Add("support@apornak.com");
                message.From = "اعلام ایرادات و پیشنهادات";
                message.ReplyTo.Add( emailmod.SenderEmail);
                message.Save();
                message.SendAndSaveCopy();
                return Json(true);
            }
            catch (Exception)
            {
                { return Json(false); }
                throw;
            }
