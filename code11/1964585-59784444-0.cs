    public class SomeData
    {
        public int Start { get; set; } 
        public int End { get; set; }
    }
    public SomeController : ApiController
    {
        public HttpResponseMessage Get([FromUri] SomeData data) { ... }
    }
