    public partial class DummyControlContainer : UserControl
    {
        private Dictionary<string, Control> _ControlMap;
        public DummyControlContainer()
        {
            InitializeComponent();
            _ControlMap = new Dictionary<string, Control>();
            this.ControlAdded +=
                new ControlEventHandler(DummyControlCollection_ControlAdded);
        }
        void DummyControlCollection_ControlAdded(object sender,
            ControlEventArgs args)
        {
            // If the added Control doesn't provide its own BindingContext,
            // set a new one
            if (args.Control.BindingContext == this.BindingContext)
                args.Control.BindingContext = new BindingContext();
            _ControlMap.Add(args.Control.Name, args.Control);
        }
        public Control this[string name]
        {
            get { return _ControlMap[name]; }
        }
    }
