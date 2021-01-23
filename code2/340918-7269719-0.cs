    protected override OnLoad(EventArgs e)
    {
        if (this.Owner is MyOwnerFormClass) { this.BackColor = Color.Blue; }
        base.OnLoad(e);
    }
