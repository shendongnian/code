    public class Tests
    {
        [TestCase]
        public void MyClassSendsAnEmail()
        {
            var emailMock = new Mock<IEmail>();
            emailMock.Setup(x=>x.Send(It.IsAny<Message>())).Verifiable();
            var subject = new ClassThatSendsEmail(emailMock.Object);
            subject.DoSomethingThatCausesAnEmailToGetSent();
            emailMock.Verify(x=>x.Send(It.IsAny<Message>()));
        }
    }
