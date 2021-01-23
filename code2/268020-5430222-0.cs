            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("xx");
            mm.To.Add("xx");
            mm.Subject = "Ant Subject"; 
            mm.Body = "Body Cha MEssag here ";
            SmtpClient ss = new SmtpClient();
            ss.Host="smtp.gmail.com";
            ss.Port = 587;
            ss.EnableSsl = true;
            
            ss.Credentials = new System.Net.NetworkCredential("xx", "xx");
            try 
            { 
                ss.Send(mm); 
                Label1.Text = "Message Sent";
                Label1.ForeColor = System.Drawing.Color.Green; 
            }
            catch (SmtpException ex) 
            { 
                Label1.Text = "Message Not Sent : \n\n " + ex.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
