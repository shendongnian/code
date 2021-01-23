    public abstract class MyClass
    {
        public IList<string> MyList { get; private set; }
        public MyClass()
        {
             this.MyList = this.CreateMyList();
        }
        protected abstract IList<string> CreateMyList();
    }
    public class MyDerived : MyClass
    {
        protected override IList<string> CreateMyList()
        {
            return new ObservableCollection<string>();
        }
    }
