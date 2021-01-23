    <system.net>
        <mailSettings>
          <smtp deliveryMethod="Network" from="MY_GMAIL_EMAIL">
            <network defaultCredentials="false" host="smtp.gmail.com" port="587" userName="MY_GMAIL_USERNAME" password="MY_GMAIL_PASSWORD" />
          </smtp>
        </mailSettings>
      </system.net>
    MailMessage message = new MailMessage() {
                                  Subject = "Subject",
                                  Body = "Body"
                              };
    message.To.Add(new MailAddress("someemail@domain.com", "Some name"));
    SmtpClient smtpClient = new SmtpClient();
    smtpClient.EnableSsl = true;
    smtpClient.Send(message);
