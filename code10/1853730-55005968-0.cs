    public class ClassThatSendsEmail
    {
        private readonly IEmail _email;
        public ClassThatSendsEmail(IEmail email)
        {
            _email = email;
        }
        public void DoSomethingThatCausesAnEmailToGetSent()
        {
            var message = new Message {To = "bob@bob.com", Body = "Hi, Bob!"};
            _email.Send(message);
        }
    }
