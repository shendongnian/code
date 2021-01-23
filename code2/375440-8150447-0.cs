    public partial class baseForm : Form
        {
            bool canShowControls;
    
            public baseForm(bool canShowBaseControls)
                : this()
            {
                InitializeComponent();
                canShowControls = canShowBaseControls;
            }
            public baseForm()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                HideControls();
            }
    
            void HideControls()
            {
                this.button1.Visible = canShowBaseControls;
                this.txtBox.Text = canShowBaseControls;
            }
        }
    public partial class childForm : baseForm
        {
            public childForm()
            {
                InitializeComponent();
            }
            public childForm(bool canShowBaseControl = true)
                : base(canShowBaseControl)
            {
    
            }
        }
