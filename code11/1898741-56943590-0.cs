    class node {
        private int _v;
        public int v
        {
            get { return _v; }
            set {
                var lln = LL.Find(this);
                var previousnode = lln.Previous.Value;
                var nextnode = lln.Next.Value;
                if (value != _v &&
                    value > previousnode.v &&
                    value < nextnode.v) {
                    _v = value;
                    OnPropertyChanged(nameof(node));
                }
            }
        }
    }
