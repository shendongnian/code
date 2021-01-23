    int nClicks;
    event EventHandler TrippleClick;
    public Form1()
    {
        InitializeComponent();
        this.button1.Click += new System.EventHandler(this.button1_Click);
        nClicks = 0;
        TrippleClick = new EventHandler(OnTrippleClick);
    }
    void OnTrippleClick(object sender, EventArgs e)
    {
        MessageBox.Show("Tripple click");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        nClicks++;
        if (nClicks == 3)
        {
            TrippleClick(sender, e);
            nClicks = 0;
        }
    }
