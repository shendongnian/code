    public partial class Form1 : Form
    {
        private PenFilter penFilter;
        public Form1()
        {
            InitializeComponent();
            penFilter = new PenFilter(this);
        }
    
        protected override void OnActivated(EventArgs e)
        {
            Application.AddMessageFilter(penFilter);
            base.OnActivated(e);
        }
        protected override void OnDeactivate(EventArgs e)
        {
            Application.RemoveMessageFilter(penFilter);
            base.OnDeactivate(e);
        }
    }
