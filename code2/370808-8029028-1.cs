    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace SOPasteTextBox
    {
        public class ClipboardEventArgs : EventArgs
        {
            public string ClipboardText { get; set; }
            public ClipboardEventArgs(string clipboardText)
            {
                ClipboardText = clipboardText;
            }
        }
    
        class PasteAwareTextBox : TextBox
        {
            public event EventHandler<ClipboardEventArgs> Pasted;
    
            private const int WM_PASTE = 0x0302;
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_PASTE)
                {
                    var evt = Pasted;
                    if (evt != null)
                    {
                        evt(this, new ClipboardEventArgs(Clipboard.GetText()));
                    }
                    return;
                }
    
                base.WndProc(ref m);
            }
        }
    
        static class Program
        {
            private static PasteAwareTextBox[] _textBoxes;
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                var mainForm = new Form();
                _textBoxes = Enumerable.Range(0, 8).Select(x => new PasteAwareTextBox() {Top = x*20}).ToArray();
                _textBoxes[0].Pasted += DoPaste;
                foreach (var box in _textBoxes)
                {
                    mainForm.Controls.Add(box);
                }
                Application.Run(mainForm);
            }
    
            private static void DoPaste(object sender, ClipboardEventArgs e)
            {
                if (String.IsNullOrWhiteSpace(e.ClipboardText))
                    return;
    
                int i = 0;
                var text = e.ClipboardText.Split('-').Take(_textBoxes.Length);
                foreach (string part in text)
                {
                    _textBoxes[i++].Text = part;
                }
            }
        }
    }
