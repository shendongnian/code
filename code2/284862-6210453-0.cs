    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        protected virtual void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
