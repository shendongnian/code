    public class MyControl : Control
    {
        private Control _parent;
        public MyControl()
        {
            InitializeComponent();
        }
        public MyControl(Control parent) : this()
        {
            _parent = parent;
        }
    }
