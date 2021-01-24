    [TestClass]
    public class FloorManagerTests {
        [TestMethod]
        public void Should_Create_Default_FloorManager() {
            //Arrange
            FloorManager subject = null;
            //Act
            subject = new FloorManager();
            //Assert - FluentAssertions
            subject.Should().NotBeNull();
            subject.Floors.Should()
                .NotBeNull()
                .And.HaveCount(0);
        }
        [TestMethod]
        public void Should_Add_Floor() {
            //Arrange
            string floorName = "First Floor";
            var floor = new FloorInfo { Name = floorName };
            var subject = new FloorManager();
            //Act
            subject.Add(floor);
            //Assert - FluentAssertions
            subject.Floors.Should().HaveCount(1);
        }
        [TestMethod]
        public void Should_FindFloorByName() {
            //Arrange
            string expected = "First Floor";
            var floor = new FloorInfo { Name = expected };
            var subject = new FloorManager();
            subject.Add(floor);
            //Act
            FloorInfo actual = subject.FindFloorByName(expected);
            //Assert - FluentAssertions
            actual.Should().NotBeNull();
            actual.Name.Should().Be(expected);
        }
    }
