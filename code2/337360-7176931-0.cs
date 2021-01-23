    public bool IsMailAddress(string addParam)
            {
                try
                {
                    MailAddress mail = new MailAddress(addParam);
                    string address = mail.Address;
    
                    //not handled by MailAdress, which is a shame
                    return Regex.IsMatch(mail.Host, @"(\w+)\.(\w+)");
                }
                catch (FormatException)
                {
                    //address is invalid
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
