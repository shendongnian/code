    public partial class FormC : Form
    {
        public FormC()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) =>
            {
                GlobalStaticClass.OnFormClosed(sender, e);
            };
        }
    }
