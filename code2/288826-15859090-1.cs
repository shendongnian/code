    private void Form1_Load(object sender, EventArgs e)
    {
        this.AutoSize = true;
        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    
        // no smaller than design time size
        this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
        // no larger than screen size
        this.MaximumSize = new System.Drawing.Size((int)System.Windows.SystemParameters.PrimaryScreenWidth, (int)System.Windows.SystemParameters.PrimaryScreenHeight);
    
        // rest of your code here...
    }
