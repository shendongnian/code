    public interface IConfigurationWrapper
    {
      IDictionary<string, string> Properties { get; }
      T GetSection<T>(string name) where T : ConfigurationSection;
    }
    public class ConfigurationWrapper : IConfigurationWrapper
    {
      // implementation with with ConfigurationManager.GetSection or just placeholders
    }
    public interface IProduct
    {
      string Name { get; }
    }
    public class Product : IProduct
    {
      readonly IConfigurationWrapper m_configuration;
      public Product(string key, IConfigurationWrapper configuration)
      {
        m_configuration = configuration;
      }
      public string Name
      {
        get { // use m_configuration to get name from .config }
      }
    }
    public class ProductFactory
    {
      readonly IConfigurationWrapper m_configuration;
      public ProductFactory(IConfigurationWrapper configuration)
      {
        m_configuration = configuration;
      }
      public IProduct CreateProduct(string key)
      {
        return new Product(key, m_configuration);
      }
    }
