    private void Form1_Load(object sender, EventArgs e)
    {
        // no smaller than design time size
        this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
        // no larger than screen size
        this.MaximumSize = new System.Drawing.Size((int)System.Windows.SystemParameters.PrimaryScreenWidth, (int)System.Windows.SystemParameters.PrimaryScreenHeight);
        this.AutoSize = true;
        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    
        // rest of your code here...
    }
