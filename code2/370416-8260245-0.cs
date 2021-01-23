    public partial class MyFontDialog : Form
    {
        private FontListBox _fontListBox;
    
        public MyFontDialog()
        {
            InitializeComponent();
    
            _fontListBox = new FontListBox();
            _fontListBox.Dock = DockStyle.Fill;
            Controls.Add(_fontListBox);
        }
    }
