    public partial class Form1 : Form
    {
        private const int CS_NOCLOSE = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mdiCp = base.CreateParams;
                mdiCp.ClassStyle = mdiCp.ClassStyle | CS_NOCLOSE;
                return mdiCp;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
