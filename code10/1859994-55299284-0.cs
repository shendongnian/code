    public class ViewModel
    {
        public ObservableCollection<CircleItem> CircleItems { get; }
            = new ObservableCollection<CircleItem>();
        public ObservableCollection<ArrowItem> ArrowItems { get; }
            = new ObservableCollection<ArrowItem>();
        public CompositeCollection Shapes { get; }
            = new CompositeCollection();
        public ViewModel()
        {
            Shapes.Add(new CollectionContainer { Collection = CircleItems });
            Shapes.Add(new CollectionContainer { Collection = ArrowItems });
        }
    }
