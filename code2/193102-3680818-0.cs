    public interface IAccessPoint
    {
        int BackHaulMaximum { get; set; }
    
        bool BackHaulMaximumReached();
        void EmailNetworkProvider();
    }
    
    public class AccessPoint : IAccessPoint
    {
        private IMailProvider Mailer { get; set; }
    
        public AccessPoint( IMailProvider provider )
        {
            this.Mailer = provider ?? new DefaultMailProvider();
        }
    
        public int BackHaulMaximum { get; set; }
    
        public bool BackHaulMaximumReached()
        {
            if (BackHaulMaximum > 80)
            {
                EmailNetworkProvider();
                return true;
            }
            return false;
            }
    
        public void EmailNetworkProvider()
        {
            this.Mailer.SendMail(...);
        }
    }
    [Test]
    public void NetworkProviderShouldBeEmailedWhenBackHaulMaximumIsReached()  
    {  
        var mailerMock = MockRepository.GenerateMock<IMailProvider>();  
  
        mailerMock .Expect( m => m.SendMail( ... specify argument matches ... ) ); 
  
        var accessPoint = new AccessPoint( mailerMock ); 
  
        accessPoint.BackHaulMaximum = 81;
        Assert.IsTrue( accessPoint.BackHaulMaximumReached() );
        mailerMock.VerifyAllExpectations();
    }
