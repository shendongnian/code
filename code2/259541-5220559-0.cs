    public Form1()
    {
        InitializeComponent();
        panel1.Scroll += new ScrollEventHandler(panel1_Scroll);
    }
    
    void panel1_Scroll(object sender, ScrollEventArgs e)
    {
        panel2.AutoScrollPosition = new Point(0,e.NewValue);
    }
