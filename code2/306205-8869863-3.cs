    public class FileInfoCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileInfoElement();
        }
        protected override object GetElementKey (ConfigurationElement element)
        {
            return ((FileInfoElement)element).Extension;
        }
    }
