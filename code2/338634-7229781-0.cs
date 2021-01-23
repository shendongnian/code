    public class DictionaryProvider : Provider<IDictionary<string, IMyInterface>>
    {
        private IEmumerable<IMyInterface> instances;
        public DictionaryProvider(IEmumerable<IMyInterface> instances>)
        {
            this.instances = instances;
        }
        protected override IDictionary<string, IMyInterface> CreateInstance(IContext context)
        {
            return this.instances.ToDictionary(i => i.Name);
        }
    }
