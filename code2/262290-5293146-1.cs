      //Holds message information.
      System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
      //Add basic information.
      mailMessage.From = new System.Net.Mail.MailAddress(txtFrom.Text.Trim());
      mailMessage.To.Add(txtTo.Text.Trim());
      mailMessage.Subject = txtSubject.Text.Trim();
      //Create two views, one text, one HTML.
      System.Net.Mail.AlternateView plainTextView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(txtBody.Text.Trim(), null, "text/plain");
      System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(txtBody.Text.Trim() + "<image src=cid:HDIImage>", null, "text/html");
      //Add image to HTML version
      System.Net.Mail.LinkedResource imageResource = new System.Net.Mail.LinkedResource(fileImage.PostedFile.FileName, "image/jpg");
      imageResource.ContentId = "HDIImage";
      htmlView.LinkedResources.Add(imageResource);
      //Add two views to message.
      mailMessage.AlternateViews.Add(plainTextView);
      mailMessage.AlternateViews.Add(htmlView);
      //Send message
      System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
      smtpClient.Send(mailMessage);
