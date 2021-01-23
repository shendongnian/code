    public partial class BaseForm : Form
    {
        public event EventHandler Loaded;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Application.Idle += OnLoaded;
        }
        protected void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            if (Loaded != null)
            {
                Loaded(sender, e);
            }
        }
    }
