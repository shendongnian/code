    private System.Drawing.Image StateImageX { get; set; }
    private System.Drawing.Image StateImageY { get; set; }
    public delegate void DelegateRefreshControls ();
    public DelegateRefreshControls RefreshControlHandler;
    public Form1 ()
    {
        this.InitializeComponent();
        this.StateImageX = System.Drawing.Image.FromFile(@"??\ImageX.png");
        this.StateImageY = System.Drawing.Image.FromFile(@"??\ImageY.png");
        this.RefreshControlHandler += new DelegateRefreshControls(this.RefreshControls);
    }
    private void Form1_FormClosing (object sender, FormClosingEventArgs e)
    {
        this.RefreshControlHandler -= new DelegateRefreshControls(this.RefreshControls);
    }
    private void SerialPort_Activity (object sender, FormClosingEventArgs e)
    {
        this.Invoke(this.RefreshControlHandler);
    }
    public void RefreshControls ()
    {
        if (state == x) this.ToolStripStatusLabel.Image = this.StateImageX;
        if (state == y) this.ToolStripStatusLabel.Image = this.StateImageY;
    }
