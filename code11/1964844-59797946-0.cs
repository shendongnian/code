    public Size MinimumClientSize { get; set; } = new Size(500, 500);
    protected override void OnLayout(LayoutEventArgs e) {
        base.OnLayout(e); 
        this.MinimumSize = this.MinimumClientSize + (this.Size - this.ClientSize);
    }
