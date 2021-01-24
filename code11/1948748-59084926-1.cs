    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (this.Owner != null)
            this.Owner.HandleDestroyed += onOwnerHandleDestroyed;
    }
    void onOwnerHandleDestroyed(object sender, EventArgs e)
    {
        this.Close();
    }
