    [TestFixture]
    public class MyTests {
      
      OrderDto OrderDto;
      OrderDetailDto;
      [SetUp]
      public void Setup() {
        _OrderDto = new OrderDto { LastName = "Smith", CreatedById = 5, CreatedByDisplayName = "Smith2" };
        _OrderDetailDto = new OrderDetailDto {/*Sample data*/};
      }
    
      [Test]
      public void TestOrderDetailIsAddedToOrder() {
        orderDto.OrderDetails.Add(_OrderDetailDto);
      }
    }
