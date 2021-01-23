    namespace TwoWindows
    {
        public partial class Form2 : Form
        {
            public Form1 Form1Property { get; set; }
            public Form2()
            {
                InitializeComponent();
            }
            protected override void OnClosed(EventArgs e)
            {
                if (Form1Property.IsDisposed)
                    Application.Exit();
            }
        }
    }
