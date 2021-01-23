    protected override void OnResize(EventArgs e)
        {
            this.Visible = false;
            base.OnResize(e);
            this.Visible = true;
        }
