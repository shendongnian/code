    using System.Drawing;
    ...
 
    List<Point> GetBlackPixels( Bitmap bmp )
    {
        var points = new List<Point>();
        for( int y = 0; y < bmp.Height; ++y )
        {
            for( int x = 0; x < bmp.Width; ++x )
            {
                if( bmp.GetPixel( x, y ) == Color.Black )
                {
                    points.Add( new Point( x, y );
                }
            }
        }    
    }
