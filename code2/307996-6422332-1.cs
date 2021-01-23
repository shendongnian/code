    public interface IFormPartCustomatorFactory
    {
        ICustomRenderer Find(string name);
    }
    [Export(typeof(IFormPartCustomerFactory)), PartCreationPolicy(CreationPolicy.Shared)]
    public class FormPartCustomatorFactory : IFormPartCustomatorFactory
    {
        private IEnumerable<Lazy<ICustomRenderer, ICustomRendereMetadata>> _renderers;
        [ImportingConstructor]
        public FormPartCustomatorFactory(IEnumerable<Lazy<ICustomRenderer, ICustomRendererMetadata>> renderers)
        {
            if (renderers == null)
                throw new ArgumentNullException("renderers");
            _renderers = renderers;
        }
        public ICustomRenderer Find(string name)
        {
            return _renders
                .Where(r => r.Metadata.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                .Select(r => r.Value)
                .FirstOrDefault();
        }
    }
