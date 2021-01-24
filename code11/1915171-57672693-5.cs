    public class DayTodayTests
    {
        [Test]
        public void ReturnsDateAndTime()
        {
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(dtp => dtp.Now()).Returns(new DateTime(2019, 8, 27, 10, 0, 0));
            var controller = new DayTodayController(mockedDateTimeProvider.Object);
            string result = controller.GetDate();
            string expected = "Today is Tuesday 27 August 2019 and the time is 10:00";
            Assert.AreEqual(expected, result); 
        }
    }
