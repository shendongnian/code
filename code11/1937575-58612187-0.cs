    public class ClientFactory
    {
        public IMyApi CreateClient(string url) => RestService.For<IMyApi>(url);
    }
    public class MyProject {
         private ClientFactory _factory;
         public MyProject (ClientFactory factory) {
            _factory = factory;
         }
    
        public Response DoSomething(string projectId) {
            string baseUrl = SomeOtherService.GetBaseUrlByProjectId(projectId);
            var client = _factory.CreateClient(baseUrl);
    
            return client.GetQuestionsAsync(projectId);
        }
    }
