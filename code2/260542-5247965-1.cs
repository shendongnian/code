    [TestFixture]
    public class Tester
    {
        [Test]
        public void Test()
        {
            var order = new Mock<IOrder>();
            order.Setup(n => n.AttachAsModifiedToOrders(It.IsAny<IOrder>()));
            var manipulator = new Manipulator(order.Object);
            manipulator.DoStuff();
            order.Verify(x => x.AttachAsModifiedToOrders(It.IsAny<IOrder>(), It.IsAny<Expression<Func<IOrder, object[]>>>()), Times.Once());
        }
    }
