    //Instantiate EmailVerify
    EmailVerify.EmailVerify ev = new EmailVerify.EmailVerify();
     
    //Assign ReturnValues to the VerifyEmail method and pass in: email and License Key
    EmailVerify.ReturnValues rv = ev.VerifyEmail("info@cdyne.com", "0");
     
    //Assign ReturnValues to the VerifyEmailWithTimeout method and pass in: email, timeout, and License Key
    EmailVerify.ReturnValues rvt = ev.VerifyEmailWithTimeout("info@cdyne.com", "5", "0"); 
     
    //Get the response for VerifyEmail (you can choose which returns to use)
    Console.WriteLine(rv.ValidLicenseKey);
    Console.WriteLine(rv.CorrectSyntax);
    Console.WriteLine(rv.EmailDomainFound);
    Console.WriteLine(rv.EmailDisposable);
    Console.WriteLine(rv.DomainVerifiesEmail);
    Console.WriteLine(rv.DomainAcceptsMail);
    Console.WriteLine(rv.EmailVerified);
    Console.WriteLine(rv.Timeout);
    Console.WriteLine(rv.DomainServersDown);
    Console.WriteLine(rv.GoodEmail);
     
    //Get the response to VerifyEmailWithTimeout (only using chosen responses)
    Console.WriteLine(rvt.EmailDisposable);
    Console.WriteLine(rvt.DomainVerifiesEmail);
    Console.WriteLine(rvt.DomainAcceptsMail);
    Console.WriteLine(rvt.EmailVerified);
    Console.WriteLine(rvt.Timeout);
    Console.WriteLine(rvt.DomainServersDown);
    Console.WriteLine(rvt.GoodEmail);
