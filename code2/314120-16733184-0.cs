    {
    SmtpClient client = new SmtpClient("188.125.69.59");//you can put the ip adress or the dns of smtp.mail.yahoo.com
                    // Specify the e-mail sender.
                    // Create a mailing address that includes a UTF8 character
                    // in the display name.
                    MailAddress from = new MailAddress("from@yahoo.fr");
                    // Set destinations for the e-mail message.
                    MailAddress to = new MailAddress("to@gmail.com");
                    // Specify the message content.
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "This is a test e-mail message sent by an application. ";
                    // Include some non-ASCII characters in body and subject.
                    string someArrows = new string(new char[] {'\u2190', '\u2191', '\u2192', '\u2193'});
                    message.Body ="cc";
                    message.BodyEncoding =  System.Text.Encoding.UTF8;
                    message.Subject = "test message 1";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    string userState = "test message1";
                    MessageBox.Show("sending"); 
                    client.Port = 25;
                   // client.Timeout = 40000;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Credentials = new System.Net.NetworkCredential("from@yahoo.fr", "pass");
                    //client.SendAsync(message, userState);
                    client.Send(message);
                    MessageBox.Show("Sending message... press c to cancel mail. Press any other key to exit.");
                    string answer = Console.ReadLine();
                    // If the user canceled the send, and mail hasn't been sent yet,
                    // then cancel the pending operation.
                   // if (answer.StartsWith("c") && mailSent == false)
                    //{
                      //  client.SendAsyncCancel();
                    //}
                    // Clean up.
                    message.Dispose();
                    MessageBox.Show("Goodbye.");
    }
