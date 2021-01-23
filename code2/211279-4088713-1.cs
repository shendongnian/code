    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            // set width to 1/2 of screen
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            screenBounds.Width = screenBounds.Width / 2;            
            this.MaximizedBounds = screenBounds;
            // maximize
            this.WindowState = FormWindowState.Maximized;
        }
    }
