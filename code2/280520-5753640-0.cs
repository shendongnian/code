    Begin Transaction
        Receive Command
        Call Aggregate Method 
            Publish Events // will only be published if the transaction succedes
    Commit Transaction
    Begin Transaction
        Receive Event
        Send Email
    End Transaction
