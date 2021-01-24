    public class Test<T> : ObservableCollection<T>
    {
        public new T this[int i]
        {
            get
            {
                Debug.WriteLine("yo");
                return base[i];
            }
            set { base[i] = value; }
        }
    }
