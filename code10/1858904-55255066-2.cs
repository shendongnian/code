    namespace FunctionTestHelper
    {
        public abstract class FunctionTest
        {
    
            protected TraceWriter log = new VerboseDiagnosticsTraceWriter();
    
            public HttpRequest HttpRequestSetup(Dictionary<String, StringValues> query, string body)
            {
                var reqMock = new Mock<HttpRequest>();
    
                reqMock.Setup(req => req.Query).Returns(new QueryCollection(query));
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(body);
                writer.Flush();
                stream.Position = 0;
                reqMock.Setup(req => req.Body).Returns(stream);
                return reqMock.Object;
            }
    
        }
    
        public class AsyncCollector<T> : IAsyncCollector<T>
        {
            public readonly List<T> Items = new List<T>();
    
            public Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
            {
    
                Items.Add(item);
    
                return Task.FromResult(true);
            }
    
            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult(true);
            }
        }
    }
    public class VerboseDiagnosticsTraceWriter : TraceWriter
        {
            
            public VerboseDiagnosticsTraceWriter() : base(TraceLevel.Verbose)
            {
                
            }
            public override void Trace(TraceEvent traceEvent)
            {
                Debug.WriteLine(traceEvent.Message);
            }
        }
