    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(ItemInfoA))]
    [XmlInclude(typeof(ItemInfoB))] 
    public class ItemInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }
    
        private readonly List<ItemInfo> items = new List<ItemInfo>();
        public List<ItemInfo> Items { get { return items; } }
        [XmlIgnore]
        public ItemInfo ParentItemInfo { get; set; }
    }
    public class ItemInfoA : ItemInfo
    {
    }
    public class ItemInfoB : ItemInfo
    {
    }
