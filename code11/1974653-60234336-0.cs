    public class MyOptions
    {
        public string ConnectionString { get; set; }
    }
    public class MyClassHere
    {
        private readonly string _connectionString;
        public MyClassHere(IOptions<MyOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        public void Foo() => Console.WriteLine(_connectionString);
    }
