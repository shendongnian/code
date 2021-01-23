    private static readonly Regex hostReg = new Regex(@"(\w+)\.(\w+)");
    public bool IsMailAddress(string addParam)
            {
                try
                {
                    MailAddress mail = new MailAddress(addParam);
                    string address = mail.Address;
    
                    //not handled by MailAdress, which is a shame
                    return hostReg.IsMatch(mail.Host);
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
