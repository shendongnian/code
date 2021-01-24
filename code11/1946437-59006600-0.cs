    private void UpdateAnchorPoint()
    {
        Size size = RenderSize;
        Point ofs = new Point(size.Width / 2, size.Height / 2);
        AnchorPoint = this.TranslatePoint(ofs, ChartCustomControl.Instance.ChartCanvas);
    }
