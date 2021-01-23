    public partial class MyFontDialog : Form
    {
        private FontListBox _fontListBox;
        private ListBox _fontSizeListBox;
    
        public MyFontDialog()
        {
            //InitializeComponent();
    
            _fontListBox = new FontListBox();
            _fontListBox.SelectedIndexChanged += OnfontListBoxSelectedIndexChanged;
            _fontListBox.Size = new Size(200, Height);
            Controls.Add(_fontListBox);
    
            _fontSizeListBox = new ListBox();
            _fontSizeListBox.Location = new Point(_fontListBox.Width, 0);
    
            Controls.Add(_fontSizeListBox);
        }
    
        private void OnfontListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _fontSizeListBox.Items.Clear();
            Font font = _fontListBox.SelectedItem as Font;
            if (font != null)
            {
                foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                {
                    if (font.FontFamily.IsStyleAvailable(style))
                    {
                        _fontSizeListBox.Items.Add(style);
                    }
                }
            }
        }
    }
