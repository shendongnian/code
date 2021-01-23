    public class FooViewModel : ViewModel
    {
        private int _fooValue;
        public int FooValue
        {
            get => _fooValue;
            set
            {
                _fooValue = value;
                OnPropertyChange();
                OnPropertyChange(nameof(Foo));
                OnPropertyChange(nameof(FooName));
            }
        }
        public Foo Foo 
        { 
            get => (Foo)FooValue; 
            set 
            { 
                _fooValue = (int)value;
                OnPropertyChange();
                OnPropertyChange(nameof(FooValue));
                OnPropertyChange(nameof(FooName));
            } 
        }
        public string FooName { get => Enum.GetName(typeof(Foo), Foo); }
        public FooViewModel(Foo foo)
        {
            Foo = foo;
        }
    }
