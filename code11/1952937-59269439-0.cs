     private async Task<string> SendMail(string to, string text)
            {
                try
                {
                    var msg = new SendGridMessage();
                    msg.SetFrom(new EmailAddress("youremail@email.com", "Your Name"));
                    msg.AddTo(to);
                    msg.SetSubject("Your subject here");
                    msg.AddContent(MimeType.Text, text);
                    var client = new SendGridClient("???"); // Your sendgrid client private id here
                    var response = await client.SendEmailAsync(msg);
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                        return "ok";
                    else return "failed"; // not happening ))
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
