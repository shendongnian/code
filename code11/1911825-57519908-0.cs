                using (SmtpClient client = new SmtpClient
                {
                    Host = "smtp.office365.com",
                    Credentials = new System.Net.NetworkCredential(userName, password),
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false
                })
                {
                    client.Send(msg);
                }
