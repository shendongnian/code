    namespace SomeNamespace
    {
        public class SomeHeader
        {
        }
        public class SomeParamaters
        {
        }
        public class SomeRequest
        {
            public SomeHeader Header;
            public SomeParamaters Parameters;
        }
    }
    using SomeNamespace;
    namespace MyNamespace
    {
        public class Worker<A>
            where A : new()
        {
            public A req;
            public void DoSomeMeaningfulWork()
            {
                req.Header = new SomeHeader();
                req.Parameters = new SomeParamaters();
            }
        }
    }
