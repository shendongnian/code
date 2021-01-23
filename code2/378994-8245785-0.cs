    public void SendEmailsRepeatedly(IEnumerable<string> emails, int sendRepeatedlyDelayMS)
    {
        AutoResetEvent resetEvent = new AutoResetEvent(false);      
        Tokenizer tokenizer = new StandardTokenizer();        
        var timer = new Timer(x => SendRepeatedlyCallback(x, emails, tokenizer), resetEvent, 0, sendRepeatedlyDelayMS);
    }
    static void SendRepeatedlyCallback(object state, IEnumerable<string> emails, StandardTokenizer tokenizer)
    {
        ...
    }
