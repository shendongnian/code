            public async Task<IActionResult> SendEmail(string email, string Message, string Subject, string EmailType, string HTMLMessageContent = "")
            {
                HTMLMessageContent = Message;
                EmailLog emailModel = new EmailLog
                {
                    EmailType = EmailType,
                    Subject = Subject,
                    EmailContent = Message,
                    FromEmail = _emailSettings.SenderEmail,
                    ToEmails = email,
                    CreatedBy = sessionData != null ? sessionData.ApplicationUserId : "",
                    OrganizationId = sessionData != null ? sessionData.OrganizationId : 0
                };
               var from = new EmailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
                var to = new EmailAddress(email, "");
                var msg = MailHelper.CreateSingleEmail(from, to, Subject, Message, HTMLMessageContent);
                var response = await client.SendEmailAsync(msg); 
                return Ok("Success");
            }
