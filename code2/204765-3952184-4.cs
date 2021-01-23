    public class GenericConfigurationElementCollection<T> :   ConfigurationElementCollection, IEnumerable<T> where T : ConfigurationElement, new()
    {
      List<T> _elements = new List<T>();
    protected override ConfigurationElement CreateNewElement()
    {
        T newElement = new T();
        _elements.Add(newElement);
        return newElement;
    }
    protected override object GetElementKey(ConfigurationElement element)
    {
        return _elements.Find(e => e.Equals(element));
    }
    public new IEnumerator<T> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }
