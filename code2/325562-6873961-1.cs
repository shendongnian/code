        public class TableItemGroup<T> where T : TableItem
        {
            public string SectionName { get; set; }
    
            private List<T> _items = new List<T>();
    
            public List<T> Items
            {
                get { return _items; }
                set { _items = value; }
            }
        }
    
        public abstract class TableItem
        {
            public string TitleLabel { get; set; }
    
            public string DetailLabel { get; set; }
    
            public string ImageName { get; set; }
        }
    
        public class AccountTableItem : TableItem
        {
            public bool SwitchSetting { get; set; }
        }
