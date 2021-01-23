    [ConfigurationCollection(typeof(LaneConfigElement), AddItemName = "Lane", CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public class LaneConfigCollection : ConfigurationElementCollection
        {
            public LaneConfigElement this[int index]
            {
                get { return (LaneConfigElement)BaseGet(index); }
                set
                {
                    if (BaseGet(index) != null)
                    {
                        BaseRemoveAt(index);
                    }
                    BaseAdd(index, value);
                }
            }
    
            public void Add(LaneConfigElement serviceConfig)
            {
                BaseAdd(serviceConfig);
            }
    
            public void Clear()
            {
                BaseClear();
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new LaneConfigElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((LaneConfigElement)element).Id;
            }
    
            public void Remove(LaneConfigElement serviceConfig)
            {
                BaseRemove(serviceConfig.Id);
            }
    
            public void RemoveAt(int index)
            {
                BaseRemoveAt(index);
            }
    
            public void Remove(String name)
            {
                BaseRemove(name);
            }
    
        }
