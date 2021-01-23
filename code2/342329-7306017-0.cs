    public class Root : XElement
    {
        public Request Request { get { return this.Element("Request") as Request; } }
        public Response Response { get { return this.Element("Response") as Response; } }
        public bool IsRequest { get { return Request != null; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="Root"/> class.
        /// </summary>
        public Root(RootChild child) : base("Root", child) { }
    }
    public abstract class RootChild : XElement { }
    public class Request : RootChild { }
    public class Response : RootChild { }
    var doc = new Root(new Request());
