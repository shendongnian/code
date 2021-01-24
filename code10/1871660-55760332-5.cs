    public class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            Program.MainForm.AddToFormSizes(this, this.Size);
        }
    }
