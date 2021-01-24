    public void CustomView(int pageIndex, View customView, Point offset)
        {
            var visualElement = Platform.CreateRenderer(customView);
            var view = visualElement.NativeView;
            var margins = View.LayoutMarginsGuide;// Get the parent view's layout
            view.LeadingAnchor.ConstraintGreaterThanOrEqualTo(margins.LeadingAnchor,(nfloat)offset.X).Active = true;
            view.TopAnchor.ConstraintGreaterThanOrEqualTo(margins.TopAnchor,(nfloat)offset.Y).Active = true;
            view.HeightAnchor.ConstraintEqualTo(100).Active = true;
            view.WidthAnchor.ConstraintEqualTo(100).Active = true;
        }
