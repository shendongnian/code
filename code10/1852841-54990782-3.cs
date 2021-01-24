    public class TestModule : NancyModule
    {
        public TestModule()
        {
    
            Get("/test", args => "test");
        }
    }
