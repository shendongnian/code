    public interface IEmailService {
        public Send(IAuthenticationDetails details, IMessage message)
    }
    public class GMail : IEmailService {
        public GMaily() { //... }
        public Send(IAuthentication details, IMessage message) {
            //...
        }
    }
    public class AnotherClasss {
        public void AMethodToSendEmail(...) {    
           // use factory or container to get instance of strategy
           strategy.Send(details, message)
        }
    }
