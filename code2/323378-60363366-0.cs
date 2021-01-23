        public static bool ValidateCredentials(string username, string password, string server, int port, bool certificationValidation)
        {
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => certificationValidation;
                        client.Connect(server, port, false);
                        client.Authenticate(username, password);
                        client.Disconnect(true);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("ValidateCredentials Exception: {0}", ex.Message));
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(string.Format("ValidateCredentials Exception: {0}", ex.Message));
            }
            return false;
        }
