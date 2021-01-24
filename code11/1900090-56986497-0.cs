    using (var msg = new MsgReader.Outlook.Storage.Message(@"C:\\test.oft"))
                {
                    var from = msg.Sender;
                    var sentOn = msg.SentOn;
                    var recipientsTo = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, false, false);
                    var recipientsCc = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.Cc, false, false);
                    var subject = msg.Subject;
                    var htmlBody = msg.BodyHtml;
                    var client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("^^service account email^^", "^^service account password^^"),
                        EnableSsl = true
                    };
                    var mailMessage = new MailMessage()
                    {
                        From = new MailAddress("^^from email^^"),
                        Subject = subject,
                        Body = htmlBody,
                        IsBodyHtml = true,
                        Priority = MailPriority.Normal
                    };
                    mailMessage.To.Add("^^to email^^");
                    client.Send(mailMessage);
                }
