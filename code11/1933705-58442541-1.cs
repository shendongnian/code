    [TestClass]
    public class NSubTests {
        [TestMethod]
        public void Should_Return_Multiple_ListValues() {
            //Arrange
            IService apiLayer = NSubstitute.Substitute.For<IService>();
            Random randomIds = new Random(9999);
            Random randomCount = new Random();
            apiLayer.GetByIds(Arg.Any<int[]>()).Returns(args => {
                var ids = args.ArgAt<int[]>(0);
                
                var count = randomCount.Next(ids.Length);
                var items = Enumerable.Range(0, count)
                    .Select(_ => new MyDto { Id = randomIds.Next() })
                    .ToList();
                return items;
            });
            //Act
            var list1 = apiLayer.GetByIds(new[] { 1, 2, 3, 4, 5 });
            var list2 = apiLayer.GetByIds(new[] { 1, 2, 3, 4, 5 });
            //Assert - FluentAssertions
            list1.Should().NotBeSameAs(list2);
        }
    }
