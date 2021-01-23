    public class Account
    {
        private Account _parent;
        public Account Parent
        {
            get { return _parent ?? this; }
            set { _parent = value; }
        }
    }
