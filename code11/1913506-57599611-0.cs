    [TestFixture]
    public class OrdersServiceTests
    {
        private OrdersService _sut;
        private Mock<ICapacityService> _capacityService;
        private Mock<IOrdersRepository> _ordersRepository;
        [SetUp]
        public void Setup()
        {
			// Executed for each test. Mocks are recreated. Tests are not influencing each other.
		
            _ordersRepository = new Mock<IOrdersRepository>();
            _capacityService = new Mock<ICapacityService>();
            _sut = new OrdersService(_ordersRepository.Object, _capacityService.Object);
        }
        [Test]
        public async Task Should_CheckCapacity_WhenCreatingOrder()
        {
            //// Arrange
			var orderEntity = new OrderEntity
			{
				Id = Guid.NewGuid(),
			};
            //// Act
            await _sut.CreateAsync(orderEntity);
            //// Assert
            _capacityService
                .Verify(
                    x => x.CheckCapacity(
                        It.Is<Guid>(g => g.Equals(orderEntity.Id)))),
                    Times.Once);
        }
	}
