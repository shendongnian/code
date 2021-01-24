    Consent cust_some = new Consent
    {
        // Headers
        headers = new headers 
        {
           myRequest = "someIDhere",
           CorrelationID = "1234567890",
           Token = "areallylongstringgoeshereastoken"
           Content_Type = "application/x-www-form-urlencoded"
        }
        // Body
        body = new body
        {
            // Initalize properties here
            access = new access
            {
                // Initalize properties here
            }
            // ... Initalize other properties ...
        };
    }
