    using System; 
    using System.Windows.Forms; 
     
    namespace Controlls 
    { 
        public enum ToolboxButtonType { Potrdi, Brisi, Novo, Nazaj, Naprej } 
        public partial class Toolbar : UserControl 
        { 
            public Toolbar() 
            { 
                InitializeComponent(); 
            } 
     
            private void pbNaprej_Click(object sender, EventArgs e) 
            { 
                OnToolboxClick(ToolboxButtonType.Naprej);
            } 
     
            private void pbNazaj_Click(object sender, EventArgs e) 
            { 
                OnToolboxClick(ToolboxButtonType.Nazaj);
            } 
     
            private void pbNovo_Click(object sender, EventArgs e) 
            { 
                OnToolboxClick(ToolboxButtonType.Novo);
            } 
     
            private void bpbBrisi_Click(object sender, EventArgs e) 
            { 
                OnToolboxClick(ToolboxButtonType.Brisi);
            } 
     
            private void pbPotrdi_Click(object sender, EventArgs e) 
            { 
                 OnToolboxClick(ToolboxButtonType.Potrdi);
            } 
     
            private void txtOd_TextChanged(object sender, EventArgs e) 
            { 
                 OnTextChanged(txtOd.Text);
            } 
        }
        private OnToolboxClick(ToolboxButtonType button)
        {
            if (ToolboxClick != null)
            {
                ToolboxClick(this, new ToolboxClickEventArgs(button));
            }
        }
        private OnTextChanged(string text)
        {
            if (ToolboxTextChanged!= null)
            {
                ToolboxTextChanged(this, new ToolboxTextChangedEventArgs(text));
            }
        }
        public class ToolboxTextChangedEventArgs: EventArgs
        {
            public string Text { get; private set; }
            public ToolboxClickEventArgs(string text) { Text = text; }
        }
        public class ToolboxClickEventArgs : EventArgs
        {
            public ToolboxButtonType Button { get; private set; }
            public ToolboxClickEventArgs(ToolboxButtonType button) { Button = button; }
        }
        public event EventHandler<ToolboxClickEventArgs> ToolboxClick;
        public event EventHandler<ToolboxTextChangedEventArgs> ToolboxTextChanged;
    } 
