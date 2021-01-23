    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.ctlRBContent1_GetBuildName -= _ctlBottom.GetBuildName;
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
