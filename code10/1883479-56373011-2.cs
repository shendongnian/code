    [TestFixture]
    public class CustomerTests
    {
        private Customer _customer;
        private Mock<IMyService> _myService;
        [SetUp]
        public void Initialize()
        {
            _myService = new Mock<IMyService>();
            _customer = new Customer(_myService.Object);
        }
        [Test]
        public void GivenIdWhenCustomerNameByIdThenCustomerNameReturned()
        {
            const int id = 10;
            const string customerName = "Victoria";
            _myService.Setup(s => s.ReadCustomerNameById(id)).Returns(customerName);
            var result = _customer.CustomerNameById(id);
            Assert.AreEqual(result, customerName);
        }
        [Test]
        public void GivenIdWhenCustomerNameByIdThenException()
        {
            _myService.Setup(s => s.ReadCustomerNameById(It.IsAny<int>())).Throws<Exception>();
            Assert.Throws<Exception>(() => _customer.CustomerNameById(10));
        }
    }
