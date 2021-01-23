    using System.Windows.Forms;
    namespace InternetExplorerExtension
    {
        public partial class HighlighterOptionsForm : Form
        {
            public HighlighterOptionsForm()
            {
                InitializeComponent();
            }
    
            public string InputText
            {
                get { return this.textBox1.Text; }
                set { this.textBox1.Text = value; }
            }
        }
    }
