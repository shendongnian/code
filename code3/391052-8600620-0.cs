    [DataContract]
    public class SpecifiedItemCollection
    {
        public ItemCollection<SpecifiedItem> Base;
        public SpecifiedItemCollection()
        {
            Base = new ItemCollection<SpecifiedItem>();
        }
        //...
    }
