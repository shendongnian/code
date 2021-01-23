    public class ShiSettingCollection : ConfigurationElementCollection
       {
          public ShiSettingElements this[int index]
          {
             get
             {
                return base.BaseGet(index) as ShiSettingElements;
             }
             set
             {
                if (base.BaseGet(index) != null)
                {
                   base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
             }
          }
          protected override System.Configuration.ConfigurationElement CreateNewElement()
          {
             return new ShiSettingElements();
          }
    
          protected override object GetElementKey(ConfigurationElement element)
          {
             return ((ShiSettingElements)element).Key;
          }
       }
