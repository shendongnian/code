    public Form1()
    {
        InitializeComponent();
        Shown += Form1_Shown;
        panel1.Dock = DockStyle.Fill;
        panel2.Dock = DockStyle.Fill;
    }
    
    void Form1_Shown(object sender, EventArgs e)
    {
        panel1.BringToFront();
        Update();
        Thread.Sleep(3000);
        panel2.BringToFront();
        Update();
        Thread.Sleep(3000);
        panel1.BringToFront();
    }
