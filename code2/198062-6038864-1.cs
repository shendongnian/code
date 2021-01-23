        public WorkspacePanel()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                runtimeConstructor();
            }
        }
        private void runtimeConstructor()
        {
            MyLibraryClass foo = new MyLibraryClass();
        }
