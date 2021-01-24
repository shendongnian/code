    public class FormBase : Form
    {
        public FormBase() => InitializeComponent();
        protected override void OnHandleCreated(EventArgs e)
        {
             base.OnHandleCreated(e);
             Program.MainForm.AddToFormSizes(this, this.Size);
        }
    }
