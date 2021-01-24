    class AutoTopLevelPanel : Panel
    {
        private Control parentInternal;
        private int parentIndex = -1;
        private Point locationInternal;
    
        public AutoTopLevelPanel()
        {
            BorderStyle = BorderStyle.Fixed3D;
        }
    
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
    
            if (parentIndex == -1)
            {
                parentIndex = Parent.Controls.IndexOf(this);
            }
            if (base.TopLevelControl != this)
            {
                parentInternal = Parent;
                locationInternal = Location;
                Location = Parent.PointToScreen(Location);
                Parent = null;
                SetTopLevel(true);
            }
        }
    
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (base.TopLevelControl == this)
            {
                SetTopLevel(false);
                Parent = parentInternal;
                Parent.Controls.SetChildIndex(this, parentIndex);
                Location = locationInternal;
            }
        }
    
    }
