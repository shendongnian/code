    public TablessControl() {
        this.SizeMode = TabSizeMode.Fixed;
    }
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        if (!this.DesignMode) this.ItemSize = new System.Drawing.Size(0, this.ItemSize.Height);
    }
