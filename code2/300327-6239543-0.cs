    public class DoSomeActionParametersBuilder
    {
        public string A { get; set; }
        public string B { get; set; }
        public DateTime C { get; set; }
        public OtherEnum D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public DoSomeActionParameters Build()
        {
            return new DoSomeActionParameters(A, B, C, D, E, F);
        }
    }
    public class DoSomeActionParameters
    {
        public string A { get; private set; }
        public string B { get; private set; }
        public DateTime C { get; private set; }
        public OtherEnum D { get; private set; }
        public string E { get; private set; }
        public string F { get; private set; }
        public DoSomeActionParameters(string a, string b, DateTime c, OtherEnum d, string e, string f)
        {
            A = a;
            // etc.
        }
    }
    // usage
    var actionParams = new DoSomeActionParametersBuilder
    {
        A = "value for A",
        C = DateTime.Now,
        F = "I don't care for B, D and E"
    }.Build();
    result = foo.DoSomeAction(actionParams, out code);
