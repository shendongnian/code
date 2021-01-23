    [TestMethod()] 
    public void SendEmailTest() 
    { 
        SESEmailProvider target = new SESEmailProvider(); 
 
        List<string> ToEmailAddresses = new List<string>() {"someone@gmail.com"}; 
        string FromEmailAddress = "no-reply@mydomain.com"; 
        string Subject = "Test"; 
        string EmailBody = "Hello world."; 
        string expected = string.Empty; 
        string actual; 
        actual = target.SendEmail(ToEmailAddresses, FromEmailAddress, Subject, EmailBody); 
        Assert.AreEqual(expected, actual); 
        Assert.Inconclusive("Verify the correctness of this test method."); 
    } 
