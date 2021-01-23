    public class Emailer{
       private IEmailProvider _provider;
    
       public Emailer(IEmailProvider provider){
          _provider = provider;
       }
    
       public SendEmail(...){
          _provider.SendEmail();
       }
    }
    
    interface IEmailProvider{
       SendEmail(...);
    }
    
    public RealEmailProvider : IEmailProvider{
       // ... real code to implement send email method
    }
    
    public FakeEmailProvider : IEmailProvider{
       public SendEmail(...){ /* Do Nothing? */ }
    }
