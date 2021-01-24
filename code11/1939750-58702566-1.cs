    [TestClass]
    public class DictionaryTests {
        [TestMethod]
        public void Sohuld_Return_Expected_Data() {
            //Arrange
            var key = "Group1";
            var dto = new Dto { Name = "Account1" };
            var group = new List<Dto> { dto };
            var dictionary = new Dictionary<string, List<Dto>> {
                { key, group }
            };
            var provider = A.Fake<IProvider>();
            A.CallTo(() => provider.Load()).Returns(dictionary);
            var filter = A.Fake<IFilter>();
            A.CallTo(() => filter.Filter(A<Dictionary<string, List<Dto>>>._))
                .Returns(dictionary);
            var subjectUnderTest = new Parser(filter, provider);
            //Act
            var actual = subjectUnderTest.GetData();
            //Assert - using FluentAssertions
            actual.ContainsKey(key).Should().BeTrue();
            actual.ContainsValue(group).Should().BeTrue();
        }
    }
