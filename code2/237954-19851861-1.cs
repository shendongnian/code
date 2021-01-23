    namespace TwoWindows
    {
        public partial class Form1 : Form
        {
            public Form2 Form2Property { get; set; }
            public Form1()
            {
                InitializeComponent();
            }
            protected override void OnClosed(EventArgs e)
            {
                if (Form2Property.IsDisposed)
                    Application.Exit();
            }
        }
    }
