C#
// Don't have a C# IDE with me, so sorry if I leave some syntax errors. 
public interface ISearchClientProvider
{
    T GetClient<T>();
}
public interface ISearchWorker
{
    void DeleteIndex(string indexName);
}
public class ElasticSearchWorker : ISearchWorker{
    private readonly ISearchClientProvider _clientProvider;
    public ElasticSearchWorker(ISearchClientProvider clientProvider){
        _clientProvider = clientProvider;
    }
    public void DeleteIndex(string indexName)
    {
        var elasticClient = _clientProvider.GetClient<IElasticClient>();
        if (elasticClient.IndexExists(indexName).Exists)
        {
            _ = elasticClient.DeleteIndex(indexName);
        }
    }
}
public class ElasticSearchClientProvider : ISearchClientProvider{/*some implementation*/}
public class AzureSearchWorker : ISearchWorker{/*some implementation*/}
public class AzureSearchClientProvider : ISearchClientProvider{/*some implementation*/}
Then test code should be something like:
C#
// would actually prefer to name it ElasticSearchWorkerTests
[TestClass]
    public class SearchTestClass
    {
        private readonly ElasticSearchWorker _searchWorker;
        private readonly ISearchClientProvider _elasticClientProvider;
        private readonly string indexName = "testIndex";
        // would prefer to name it SetupElasticSearchWorker
        [TestInitialize]
        public void SetupElasticClient()
        {
            var elasticClient = new Mock<IElasticClient>();
            // Setup for IElasticClient.IndexExists() function:
            // I don't know what is the return type of IndexExists, 
            // so I am assuming here that it is some dynamic Object
            elasticClient.Setup(c => c.IndexExists(indexName)).Returns(new {Exists = true});
            // Setup for IElasticCleint.DeleteIndex might also be necessary here.
            _elasticClientProvider = new Mock<ISearchClientProvider>();
            _elasticClientProvider.Setup(c => c.GetClient<IElasticClient>()).Returns(elasticClient.Object).Verifiable();
            _searchWorker = new ElasticSearchWorker(_elasticClientProvider);
        }
        // would prefer to name it DeleteIndexTest_GetsSearchClient, 
        // because the function does more than is checked here, e.g., Checks index, deletes index.
        [TestMethod]
        public void DeleteIndexTest()
        {
            try
            {
                searchWorker.DeleteIndex(indexName);
                searchWorkerMoq.Verify(c => c.GetClient<IElasticClient>(), Times.Once()); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
This way there will be no http requests in this test.
In general (the arguably opinionated part) if you want your code to be more unit testable:
 - Use [Ports and Adapters][1] (Hexagon, or however you want to call it) architecture
 - Rule of thumb. Do not call public methods inside of other public methods. Use [composition][2] to fix this. I used composition in this example.
 - Rule of thumb. Do not create your objects, that have behavior, inside your class. Let your [composition root][3] create them and inject them into your class as a dependency, an implementation of an interface. If it is not possible to create them in your composition root (maybe you know only at run time what kind of object you need), then use factory pattern.
 - Disclaimer. You don't need a DI container in order to use composition root pattern. You can start [with poor man's DI][4].
 - There will always be classes that are not unit testable, because some dependencies from 3rd parties will not be mockable. Your goal is to make those classes [very small][5] and then do some integration testing with them. (which, I believe, test coverage tools will also pickup)
 - Disclaimer. I have seen people mocking out HttpClient successfully, via HttpClientHandler substition. But I am yet to see a successful EF db context mock - they all fail at some point.
 - Note. There is a common belief that you should [not mock interfaces you do not own][6]. So, in this sense, my solution above is also not clean, and may get you into trouble at some point in the future.
  [1]: https://blog.ploeh.dk/2013/12/03/layers-onions-ports-adapters-its-all-the-same/
  [2]: https://en.wikipedia.org/wiki/Composition_over_inheritance
  [3]: https://freecontent.manning.com/dependency-injection-in-net-2nd-edition-understanding-the-composition-root/
  [4]: https://blog.ploeh.dk/2014/06/10/pure-di/
  [5]: https://blog.thecodewhisperer.com/permalink/integrated-tests-are-a-scam
  [6]: https://github.com/testdouble/contributing-tests/wiki/Don't-mock-what-you-don't-own
