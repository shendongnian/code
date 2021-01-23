    protected override void OnVisibleChanged(EventArgs e)
    {
        base.OnVisibleChanged(e);
        if (Visible && !Disposing) PopulateGridView(); //<-- your population logic
    }
