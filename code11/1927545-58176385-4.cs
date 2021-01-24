    [TestClass]
    public class RandomGeneratorSpec {
        [TestMethod]
        public void GetRandomListMember_ListOfStrings() {
            List<string> strings = new List<string> { "red", "yellow", "green" };
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(strings.Count)).Returns(() => 2); // 2!
            var subject = new RandomGenerator(mockRandom.Object);
            string result = subject.GetRandomListMember(strings);
            Assert.AreEqual("green", result);
        }
    }
