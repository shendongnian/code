            private void btnSendMail_Click(object sender, EventArgs e)
            {
    
    
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),new DataColumn("Name", typeof(string)),
                        new DataColumn("Debt", typeof(string)),
                        new DataColumn("Email",typeof(string)) });
    
                dt.Rows.Add("Vasia", "130", "vasia@mail.com");
                dt.Rows.Add("Liuda", "23", "liuda@test.com");
                dt.Rows.Add("Grisa", "2560", "grisa@test.com");
                GridView1.DataSource = dt;
    
                string bodyText = BuildStringFromDT(dt);
    
                foreach (DataRow row in dt.Rows)
                {
                    string emailId = row["Email"].ToString();
                    SendEmailUsingGmail(emailId, bodyText);
                }
    
                //write code to send mail
    
            }
            private string BuildStringFromDT(DataTable dt)
            {
                List<string> final = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    List<string> temp = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        temp.Add(row[col.ColumnName].ToString());
                    }
                    final.Add(string.Join("\t", temp));
                }
                return string.Join("\r\n", final);
            }
            private void SendEmailUsingGmail(string toEmailAddress, string bodyText)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("xxx.xxx.xx");
    
                    mail.From = new MailAddress("xxxxxa@xxxx.ru");
                    mail.To.Add(toEmailAddress);
                    mail.Subject = "tgggggg ";
                    mail.Body = bodyText;
    
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("xxxxx@xxx.ru", "xxxxx");
                    //SmtpServer.EnableSsl = true;
    
                    SmtpServer.Send(mail);
                    MessageBox.Show("Informavimo laiškas išsiųstas Tiekimo skyriui bei Gamybai");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
