    public bool SendEmailAsync(string toEmail, string toName)
            {
                try
                {
                    SendEmailDelegate dc = new SendEmailDelegate(this.SendEmail);
                    AsyncCallback cb = new AsyncCallback(this.GetResultsOnCallback);
                    IAsyncResult ar = dc.BeginInvoke(toEmail, toName, cb, null);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
