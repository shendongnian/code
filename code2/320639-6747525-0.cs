    public MainPage()
        {
            InitializeComponent();
            childPage d = new childPage();
            d.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toolStripContainer1.ContentPanel.Controls.Add(d);
            d.Show();
        }
