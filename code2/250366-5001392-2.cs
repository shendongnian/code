	[TestFixture]
	public class Tester
	{
		public void MessageIsShownWhenDateIsLowerThanMaxDate()
		{
			//SetUp
			var manager = new Mock<IManager>();
			var messanger = new Mock<IMessanger>();
			
			var maxDate = DateTime.Now;
			
			manager.Setup(m => m.MaxToDate).Returns(maxDate);
			
			var cut = new ClassUnderTest (manager.Object, messanger.Object);
			
			//Act
			cut.CheckToDate();
			
			//Assert
			messanger.Verify(foo => foo.ShowMessage("message"), Times.AtLeastOnce())
		}
	}
