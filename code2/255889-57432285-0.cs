    using System.Windows.Forms;
    public class TextWatcher
    {
        private Control control;
        private string initialState;
        public TextWatcher(Control control)
        {
            this.control = control;
        }
        public void SetInitialState() => initialState = control.Text;
        public bool IsChanged => initialState != control.Text;
        public static TextWatcher Watch(Control control) => new TextWatcher(control);
    }
