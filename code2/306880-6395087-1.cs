    var sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand("select e_mail, Password from Person where Login= @Login ", sqlCon);            
    cmd.Connection.Open();            
    cmd.Parameters.Add(new SqlParameter("@Login", Email.Text));
    string email = "", password = "";
    using (SqlDataReader sdr = cmd.ExecuteReader())
    {
        while (sdr.Read())
        {
            email = sdr.GetString(0);
            password = sdr.GetString(1);
        }
    }
    cmd.Connection.Close();
    cmd.Dispose();
    SmtpClient mailClient = new SmtpClient("your smtp");
    MailMessage mailMessage = new MailMessage();
    mailMessage.From = new MailAddress("YOU");
    mailMessage.To.Add(email);
    mailMessage.Subject = "password recovery";
    mailMessage.Body = "hello " + email + " your password : " + password;
    mailMessage.IsBodyHtml = true;
                        
    mailClient.Send(mailMessage);
