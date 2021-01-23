    class Program
    {
        [ImportMany]
        private List<Lazy<IGatewayResponseReader, IDictionary<string, object>>> _readers;
        static void Main(string[] args)
        {
            CompositionContainer container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            Program program = new Program();
            container.SatisfyImportsOnce(program);
            var result = program._readers.Where(r =>            
                r.Metadata.ContainsKey(G3Reader.META_KEY) && (string)r.Metadata[G3Reader.META_KEY] == "value1")
                .First().Value;
        }
    }
