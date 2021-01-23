        protected void SendEmail(string toAddresses, string fromAddress, string MailSubject, string MessageBody, bool isBodyHtml)
        {
            SmtpClient sc = new SmtpClient("SMTP (MAIL) ADDRESS");
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("pssp@gmail.com", "OUR SYSTEM");
                
                // In case the mail system doesn't like no to recipients. This could be removed
                msg.To.Add("pssp@gmail.com");
                msg.Bcc.Add(toAddresses);
                msg.Subject = MailSubject;
                msg.Body = MessageBody;
                msg.IsBodyHtml = isBodyHtml;
                //Response.Write(msg);
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void SendEmailTOAllUser()
        {
            string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspTest;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var sbEmailAddresses = new System.Text.StringBuilder(1000);
                var quizIds = new List<int>();
                // Open DB connection.
                conn.Open();
                string cmdText = "SELECT QuizID FROM dbo.QUIZ WHERE IsSent <> 1";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            // There is only 1 column, so just retrieve it using the ordinal position
                            quizIds.Add(reader.GetInt32(0));
                        }
                    }
                    reader.Close();
                }
                string cmdText2 = "SELECT Username FROM dbo.employee";
                using (SqlCommand cmd = new SqlCommand(cmdText2, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            var sName = reader.GetString(0);
                            if (!string.IsNullOrEmpty(sName)
                            {
                                if (sbEmailAddresses.Length != 0)
                                {
                                    sbEmailAddresses.Append(",");
                                }
                                // Just use the ordinal position for the user name since there is only 1 column
                                sbEmailAddresses.Append(sName).Append("@gmail.com");
                            }
                        }
                    }
                    reader.Close();
                }
                string cmdText3 = "UPDATE dbo.Quiz SET IsSent = 1 WHERE QuizId = @QuizID";
                using (SqlCommand cmd = new SqlCommand(cmdText3, conn))
                {
                    // Add the parameter to the command
                    var oParameter = cmd.Parameters.Add("@QuizID", SqlDbType.Int);
                    // Get a local copy of the email addresses
                    var sEMailAddresses = sbEmailAddresses.ToString();
                    foreach (int quizid in quizIds)
                    {
                        string link = "<a href='http://pmv/pssp/StartQuiz.aspx?testid=" + quizid + "'> Click here to participate </a>";
                        string body = @"<b> Please try to participate in the new short safety quiz </b>"
                                            + link +
                                            @"<br /> <br />
                        This email was generated using the <a href='http://pmv/pssp/Default.aspx'>PMOD Safety Services Portal </a>. 
                        Please do not reply to this email.
                        ";
                        SendEmail(sEMailAddresses, "", "Notification Email Subject", body, true);
                        // Update the parameter for the current quiz
                        oParameter.Value = quizid;
                        // And execute the command
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }
