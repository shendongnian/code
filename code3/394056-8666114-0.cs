    public class FormBase : System.Windows.Forms.Form
    {
        private static FormWindowState _windowState = FormWindowState.Normal;
        public FormBase()
        {
            WindowState = _windowState;
        }
        protected override void OnResize(EventArgs e)
        {
            _windowState = WindowState;
            base.OnResize(e);
        }
    }
