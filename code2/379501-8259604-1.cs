    [TestFixture]
    public class MyTest
    {        
        Dictionary<EmailAccountType, IEmailTransportHandler> _protocolHandlers;
        Mock<IEmailTransportHandler> _mockEmailTransportHander = new Mock<IEmailTransportHandler>();        
        [SetUp]
        public void Init()
        {
            _protocolHandlers = new Dictionary<EmailAccountType, IEmailTransportHandler>
                        {
                            {EmailAccountType.Pop3, _mockEmailTransportHander.Object},
                            {EmailAccountType.IMAP, _mockEmailTransportHander.Object} 
                        };
        }
        [Test]
        public void Test1() 
        {
            _mockEmailTransportHander.Setup(m => m.Test()).Returns(false);
            // Rest of test
        }
        [Test]
        public void Test2() 
        {
            _mockEmailTransportHander.Setup(m => m.Test()).Returns(true);
            // Rest of test
        }
    }
