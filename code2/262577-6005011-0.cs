    [MonoTouch.Foundation.Export("editingRectForBounds:")]
    public RectangleF MyEditingRect()
    {
        if (iWantToOverrideTheDefaultRect)
        {
            return mySpecialRect;
        }
        return base.EditingRect(this.Bounds);
    }
