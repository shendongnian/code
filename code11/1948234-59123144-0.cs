  public ActionResult SendEmail(User user)
        {
            HostingEnvironment.QueueBackgroundWorkItem(ct =>
            {
                // Prepare SMTP client
                SmtpClient Client = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Host = "smtp.test.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("smtpuser", "smtppass")
                };
                // Prepare message
                MailMessage MailMessage = new MailMessage()
                {
                    From = new MailAddress("sender@mydomain.com"),
                    Subject = "Test",
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8
                };
                MailMessage.To.Add(new MailAddress("recipient@mydomain.com"));
                MailMessage.Body = TestMessage;
                // Send mail
                Client.Send(MailMessage);
            });
            // Return success view
            return View("ContactSuccess");
        }
if you want to go over advance scenarios , like handling many background jobs you can use  [Hangfire](http://www.example.com/)  library
[this blog post](https://www.hanselman.com/blog/HowToRunBackgroundTasksInASPNET.aspx) will also help you solve your problem
