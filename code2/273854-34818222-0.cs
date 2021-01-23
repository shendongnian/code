    public class A
    {
        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id < 0)
                    throw new InvalidOperationException("...");
                if (value < 0)
                    throw new ArgumentException("...");
                _id = value;
            }
        }
    }
