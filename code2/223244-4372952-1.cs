    public Settings(ThemeableForm requestingForm)
    {
        rssReaderMain = requestingForm as ThemeableForm;
        InitializeComponent();
    }
    private ThemeableForm rssReaderMain = null;
    private void button2_Click(object sender, EventArgs args) {
        // Appearence settings for DEFAULT THEME
        if (cbThemeSelect.SelectedIndex == 1)
        {
            this.rssReaderMain.TxtRSSURLBGProperty = Color.DarkSeaGreen;
            this.rssReaderMain.TxtRSSURLFGProperty = Color.White;            
            [......about 25 more of these....]
        }
    }
