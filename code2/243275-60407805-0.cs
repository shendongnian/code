    public partial class ParentForm: Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
    
        public string ParentProperty{get;set;}
    
        private void CreateChild()
        {
             var childForm = new ChildForm(this);
             childForm.Show();
        }
    }
    
    public partial class ChildForm : Form
    {
        private ParentForm parentForm;
    
        public ChildForm(ParentForm parent)
        {
            InitializeComponent();
    
            parentForm = parent;
            parentForm.ParentProperty = "Value from Child";
        }   
    }
