    string htmlBody = MailText;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
                // create image resource from image path using LinkedResource 
                // LinkedResource class represents an embedded external resource in email, ex: a image
                LinkedResource msLogoImageResource = new LinkedResource(GetMSLogoAssembly(), contentType)
                {
                    ContentId = "msLogoImage",
                    TransferEncoding = System.Net.Mime.TransferEncoding.Base64
                };
                LinkedResource downloadArrowImageResource = new LinkedResource(GetDownloadArrowAssembly(), contentType)
                {
                    ContentId = "downloadArrowImage",
                    TransferEncoding = System.Net.Mime.TransferEncoding.Base64
                };
                // adding the images linked to htmlView...
                htmlView.LinkedResources.Add(msLogoImageResource);
                htmlView.LinkedResources.Add(downloadArrowImageResource);
                string subjectMessage = $"Content available for download at MediaShuttle. {subject}";
                MailMessage emailMessage = new MailMessage(From, To)
                {
                    Subject = subjectMessage,
                    Body = MailText,
                    Priority = MailPriority.Normal,
                    IsBodyHtml = true
                };
                emailMessage.AlternateViews.Add(htmlView);
                SmtpClient smtpClient = new SmtpClient(emailServer);
                smtpClient.Send(emailMessage);
