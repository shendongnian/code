    //Here I extract html of the control to be sent
    StringWriter stringWrite = new StringWriter();
    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
    //pnlRpt is an asp.net panel containing the controls to be sent
    pnlRpt.RenderControl(htmlWrite);
    string htmlStr = stringWrite.ToString();
    //Here I send the message whith the html of the table
    MailMessage msg = new MailMessage();
    msg.From = new MailAddress("EmailOfSender");
    msg.To.Add("emailOfReceiver");
    msg.Subject = "your subject";
    msg.Body = htmlStr;
    msg.IsBodyHtml = true;
    SmtpClient smtp = new SmtpClient(mailServer);
    smtp.Credentials = new System.Net.NetworkCredential(userName, usePass);
    smtp.Send(msg);
    msg.Dispose();
