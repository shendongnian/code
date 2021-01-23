    public class FormBase : System.Windows.Forms.Form
    {
        private static List<FormBase> _allForms = new List<FormBase>();
        private static FormWindowState _windowState = FormWindowState.Normal;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _allForms.Add(this);
            WindowState = _windowState;
        }
        protected override void Dispose(bool disposing)
        {
            _allForms.Remove(this);
            base.Dispose(disposing);
        }
        protected override void OnResize(EventArgs e)
        {
            _windowState = WindowState;
            foreach (var form in _allForms)
            {
                if (form != this)
                {
                    form.WindowState = WindowState;
                }
            }
            base.OnResize(e);
        }
    }
