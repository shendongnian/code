    public class FormWithResult : Form
    {
        protected object FormResult { get; set; }
        public DialogResult ShowDialog(out object result)
        {
            DialogResult dr = ShowDialog();
            result = FormResult;
            return dr;
        }
        public DialogResult ShowDialog(out object result, IWin32Window win)
        {
            DialogResult dr = ShowDialog(win);
            result = FormResult;
            return dr;
        }
        public void Return(object result)
        {
            FormResult = result;
            Close();
        }
    }
