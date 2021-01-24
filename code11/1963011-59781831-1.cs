    abstract class SomeSpecialApi<TSomeTypeParam> { // just some common base type
        public abstract string doGetStuff();
    }
    
    class SomeSpecialApi1 : SomeSpecialApi<SomeTypeParam1> where SomeTypeParam1 : TSomeTypeParam {
        
        private HttpClient _client;
        
        public SomeSpecialApi(HttpClient client) {
            _client = client;
        }
        
        public override string doGetStuff() {
            return _client.get(someUrlWeDontCareAbout).Result;
        }
        
    }
    
    class SomeSpecialApi2 : SomeSpecialApi<SomeTypeParam2> where SomeTypeParam2 : TSomeTypeParam {
        
        private SomeFtpClient _client;
        
        public SomeSpecialApi(SomeFtpClient client) {
            _client = client;
        }
        
        public override string doGetStuff() {
            // it's just something very different from the previous class
            return _client.read(someOtherPathWeDontCareAboutEither).Result;
        }
        
    }
    class JobPerformer {
    
        private ILifeTimeScope _scope;
        public JobPerformer(ILifeTimeScope scope) {
            _scope = scope;
        }
        
        void PerformJob<T>() {
            while (true) {
                using (var childScope = scope.BeginLifeTimeScope()) {
                    var api = childScope.Resolve<SomeSpecialApi<T>>();
                    var result = api.doGetStuff();
                    // do something with the result
                } // here the childScope and everything resolved from it will be destroyed
                // and that's the whole purpose of the lifetime scopes.
                Thread.Sleep(1000);
            }
        }
    }
        
