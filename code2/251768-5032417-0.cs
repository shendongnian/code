    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        label1.Text = this.Width.ToString();
    }
