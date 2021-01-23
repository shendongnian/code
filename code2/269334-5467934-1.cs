    static void Main(string[] args)
    {
        TwilioRestClient client;
            
        // ACCOUNT_SID and ACCOUNT_TOKEN are from your Twilio account
        client = new TwilioRestClient(ACCOUNT_SID, ACCOUNT_TOKEN);
            
        var result = client.SendMessage(CALLER_ID, "PHONE NUMBER TO SEND TO", "The answer is 42");
        if (result.RestException != null) {
            Debug.Writeline(result.RestException.Message);
        }    
    }
