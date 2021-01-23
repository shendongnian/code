    private void DrawReversibleRectangle(int x, int y) {
      // Hide the previous rectangle by calling the methods with the same parameters.
      var rect = GetSelectionRectangle(this.PointToScreen(this.reversibleRectStartPoint), this.PointToScreen(this.reversibleRectEndPoint));
      ControlPaint.FillReversibleRectangle(rect, Color.Black);
      ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
      this.reversibleRectEndPoint = new Point(x, y);
      // Draw the new rectangle by calling
      rect = GetSelectionRectangle(this.PointToScreen(this.reversibleRectStartPoint), this.PointToScreen(this.reversibleRectEndPoint));
      ControlPaint.FillReversibleRectangle(rect, Color.Black);
      ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
    }
