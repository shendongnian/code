    public partial class ChildForm : BaseMasterForm
    {
        // set true or false. to show MasterForm background.
        public override bool ShowBackground { get { return true; } }
    
        public ChildForm()
        {
            InitializeComponent();
        }
    }
