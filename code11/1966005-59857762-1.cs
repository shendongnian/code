    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        private const int WM_PASTE = 0x0302;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool MessageBeep(int type);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE) { base.WndProc(ref m); }
            else {
                //You can sanitize the input or even stop pasting the input
                var text = SanitizeText(Clipboard.GetText());
                SelectedText = text;
            }
        }
        protected virtual string SanitizeText(string value)
        {
            if (Text.IndexOf('-') >= 0) { return value.Replace("-", ""); }
            else {
                var str = value.Substring(0, value.IndexOf("-") + 1);
                return str + value.Substring(str.Length).Replace("-", "");
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' && this.Text.IndexOf('-') >= 0) {
                e.Handled = true;
                MessageBeep(0);
            }
            else {
                base.OnKeyPress(e);
            }
        }
    }
