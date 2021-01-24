    public class DefaultTemplateFactory : ITemplateFactory {
        public ITemplate Create(string name, string alias) {
            return new Template(name, alias);
        }
    }
