    public class ObservableBool
    {
        public event EventHandler<bool> Change;
        private bool val;
        public bool Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    val = value;
                    var evt = Change;
                    evt?.Invoke(this, val);
                }
            }
        }
        public ObservableBool(bool v)
        {
            this.val = v;
        }
    }
