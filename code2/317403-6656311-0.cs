          private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MailMessage myMessage = new MailMessage();
                SmtpClient myClient = new SmtpClient("yourserver");
                myClient.Port = "587";
                myClient.Host = "your server";
                myClient.UseDefaultCredentials = false;
                myClient.Credentials = new System.Net.NetworkCredential("username", "password");
                myMessage.From = new MailAddress("sender");
                myMessage.To.Add("recipient");
                myMessage.Subject = "Subject email";
                myMessage.Body = "body email";
                myClient.EnableSsl = true;
                myClient.Send(myMessage);
            }
            catch (Exepiton ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
