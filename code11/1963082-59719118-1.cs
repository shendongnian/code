        // And an instance variable
        public ObservableCollection<Outer> Lists { get; } = new ObservableCollection<Outer>();
        public class Outer
        {
            public ObservableCollection<Inner> SubChildren { get; } = new ObservableCollection<Inner>();
        }
        public class Inner
        {
            public string Name { get; set; }
        }
