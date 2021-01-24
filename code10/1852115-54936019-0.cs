    public class BaseRepositoryTests
    {
        private readonly BaseRepository<Model> subject;
        private readonly Mock<ICypherFluentQuery> mockCypher;
        private readonly Mock<ICypherFluentQuery> mockMatch;
        private readonly Mock<IGraphClient> mockGraphClient;
        public BaseRepositoryTests()
        {
            mockMatch = new Mock<ICypherFluentQuery>();
            mockCypher = new Mock<ICypherFluentQuery>();
            mockCypher
                .Setup(x => x.Match(It.IsAny<string[]>()))
                .Returns(mockMatch.Object);
            mockGraphClient = new Mock<IGraphClient>();
            mockGraphClient
                .Setup(x => x.Cypher)
                .Returns(mockCypher.Object);
            subject = new BaseRepository<Model>(mockGraphClient.Object);
        }
        
        [Fact]
        public async Task CanGetAll()
        {
            IEnumerable<Model> mockReturnsResult = new List<Model> { new Model() };
            var mockReturn = new Mock<ICypherFluentQuery<Model>>();
            
            mockMatch
                .Setup(x => x.Return(It.IsAny<Expression<Func<ICypherResultItem, Model>>>()))
                .Returns(mockReturn.Object);
            mockReturn
                .Setup(x => x.ResultsAsync)
                .Returns(Task.FromResult(mockReturnsResult));
            
            var result = await subject.GetAllAsync();
            Assert.Single(result);
        }
        public class Model { }
    }
