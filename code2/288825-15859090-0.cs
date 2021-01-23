    private void Form1_Load(object sender, EventArgs e)
    {
        this.AutoSize = true;
        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    
        // no smaller than design time size
        this.MinimumSize.Width = this.Width;
        this.MinimumSize.Height = this.Height;
    
        // no larger than screen size
        this.MaximumSize.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        this.MaximumSize.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
    
        // rest of your code here...
    }
