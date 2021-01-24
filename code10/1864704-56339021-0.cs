    public class FooControllerTest
    {
        private FooController _sut;
        
        [Setup]
        public void Setup()
        {
            _sut = new FooController();
            _sut.Configuration = new System.Web.Http.HttpConfiguration();
            _sut.Request = new System.Net.Http.HttpRequestMessage();
        }
    }
