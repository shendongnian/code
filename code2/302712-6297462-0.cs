    protected override void OnPreRender(EventArgs e)
    {
        if (this.Items == null)
        {
            this.Items = new Dictionary<string, string>();
        }
        base.OnPreRender(e);
    }
