    [TestMethod]
    public static void SomeMethod_Test()
    {
       // After that all calls to MyNamespace.MailSender.SendMail whould
       // return true
       MyNamespace.Moles.MMailSender.SendMail = () => true;
       BusinessLogicClass.SomeMethod();
    }
