    public partial class FormMain : Form
    {
        private BlockProperties _bp = new BlockProperties();
        public FormMain()
        {
            InitializeComponent();
            pgProperties.SelectedObject = _bp;
        }
    [...]
    }
