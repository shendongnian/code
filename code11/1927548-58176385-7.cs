    [TestClass]
    public class RandomGeneratorSpec {
        [TestMethod]
        public void GetRandomListMember_ListOfStrings() {
            //Arrange
            List<string> strings = new List<string> { "red", "yellow", "green" };
            string expected = "green";
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(strings.Count)).Returns(() => 2); // 2!
            var subject = new RandomGenerator(mockRandom.Object);
            //Act
            string actual = subject.GetRandomListMember(strings);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
