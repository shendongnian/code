    if( doingSomething )
    {
      using( SolidBrush brush = new SolidBrush( Color.FromArgb(128, 0, 0, 0)))
      {
          e.Graphics.FillRectangle( brush, 0, 0, width, height );
      }
    }
