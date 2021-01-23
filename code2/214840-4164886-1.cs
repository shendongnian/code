      Point mAnchorPoint = new Point(200, 200);
      Point mPreviousPoint = Point.Empty;
    
      private void panel1_MouseMove(object sender, MouseEventArgs e)
      {
         if (mPreviousPoint != Point.Empty)
         {
            // Clear last line drawn
            ControlPaint.DrawReversibleLine(PointToScreen(mAnchorPoint), PointToScreen(mPreviousPoint), Color.Pink);
         }
    
         // Update previous point
         mPreviousPoint = e.Location;
         mPreviousPoint.Offset(myPanel1.Location);
    
         // Draw the new line
         ControlPaint.DrawReversibleLine(PointToScreen(mAnchorPoint), PointToScreen(mPreviousPoint), Color.Pink);
      }
