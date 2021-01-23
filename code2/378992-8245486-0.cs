    public void SendEmailsRepeatedly(IEnumerable<SimpleEmail> emails,
                                     int sendRepeatedlyDelayMS)
    {
        Tokenizer tokenizer = new StandardTokenizer();
        Action action = () => TokenizeAndSendEmails(emails, tokenizer);    
        sendRepeatedlyTimer = new Timer(SendRepeatedlyCallback, action, 0,
                                        sendRepeatedlyDelayMS);
    }
