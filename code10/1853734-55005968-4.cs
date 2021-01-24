    [TestCase]
    public void MyClassSendsAnEmail()
    {
        var email = new EmailListDouble();
        var subject = new ClassThatSendsEmail(email);
        subject.DoSomethingThatCausesAnEmailToGetSent();
        Assert.True(email.Any(message=> message.To == "bob@bob.com" && message.Body.Contains("Bob")));
    }
