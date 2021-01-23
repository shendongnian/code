    public class Entry
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Source> Sources { get; set; }
        public Entry()
        {
            Sources = new ObservableCollection<Source>();
        }
        public CompositeCollection Items
        {
           get
           {
              return new CompositeCollection()
              {
                 new CollectionContainer() { Collection = Sources },
                 // Add other type of collection in composite collection
                 // new CollectionContainer() { Collection = OtherTypeSources }
              };
           } 
        }
   
     }
