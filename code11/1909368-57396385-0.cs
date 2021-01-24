    public class QueryResults : BindableBase 
    {
        private int _count;
        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }
    }
