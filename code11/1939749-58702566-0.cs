    public class Parser {
        private readonly IFilter filter;
        private readonly IProvider provider;
        public Parser(IFilter filter, IProvider provider) {
            this.filter = filter;
            this.provider = provider;
        }
        public Dictionary<string, List<Dto>> GetData() {
            Dictionary<string, List<Dto>> input = provider.Load();
            var dictionary = filter.Filter(input);
            return dictionary;
        }
    }
    public interface IProvider {
        Dictionary<string, List<Dto>> Load();
    }
    public interface IFilter {
        Dictionary<string, List<Dto>> Filter(Dictionary<string, List<Dto>> input);
    }
    public class Dto {
        public string Name { get; set; }
    }
