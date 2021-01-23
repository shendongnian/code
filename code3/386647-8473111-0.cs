    private void ScrollToGroupBox(GroupBox groupBox)
    {
      GeneralTransform groupBoxTransform = groupBox.TransformToAncestor(scrollViewer);
      Rect rectangle = groupBoxTransform.TransformBounds(new Rect(new Point(0, 0), groupBox.RenderSize));
      scrollViewer.ScrollToVerticalOffset(rectangle.Top);
    }
