      // create filter
    
      AForge.Imaging.Filters.HSLFiltering filter =
          new AForge.Imaging.Filters.HSLFiltering( );
      filter.Hue = new IntRange( 340, 20 );
      filter.UpdateHue = false;
      filter.UpdateLuminance = false;
      // apply the filter
    
      System.Drawing.Bitmap newImage = filter.Apply( image );
