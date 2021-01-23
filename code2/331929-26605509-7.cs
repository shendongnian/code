        private MailMessage CreateMail(SmtpClient smtp, string toAddress, string body)
        {
            var images = GetFullNamesOfImages();
            string decodedBody = WebUtility.HtmlDecode(body);
            var text = AlternateView.CreateAlternateViewFromString(decodedBody, null, MediaTypeNames.Text.Plain);
            var html = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            foreach (var image in images)
            {
                html.LinkedResources.Add(new LinkedResource(image, new ContentType("image/png"))
                                         {
                                             ContentId = Path.GetFileName(image)
                                         });
            }
            var credentials = (NetworkCredential) smtp.Credentials;
            var message = new MailMessage(new MailAddress(credentials.UserName), new MailAddress(toAddress))
                          {
                              Subject = "Some subj",
                              Body = decodedBody
                          };
            message.AlternateViews.Add(text);
            message.AlternateViews.Add(html);
            return message;
        }
