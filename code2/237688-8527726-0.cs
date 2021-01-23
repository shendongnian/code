    protected override void OnResize(EventArgs e)
        {
            myControl.Visible = false;
            base.OnResize(e);
            myControl.Visible = true;
        }
