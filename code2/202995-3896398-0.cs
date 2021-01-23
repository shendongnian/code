    public class Child
    {
        public int Value { get; set; }
    }
    class MyClassWithReadonlyCollection
    {
        private readonly ObservableCollection<Child> _children = new ObservableCollection<Child>();
        public MyClassWithReadonlyCollection()
        {
            _children.Add(new Child());
        }
        //No need to NotifyPropertyChange, because property doesnt change and collection handles this internaly
        public ReadOnlyObservableCollection<Child> Children { get { return new ReadOnlyObservableCollection<Child>(_children); } }
    }
