        public class ItemGroup<T> where T: ITableItem
        {
            public string SectionName { get; set; }
        
            public List<T> Items { get; private set; }
        
            public ItemGroup()
            {
                Items = new List<T>();
            }
        }
