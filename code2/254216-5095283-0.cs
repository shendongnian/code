    private void someTimer_Tick( ... )
    {
        Invalidate();
    }
    protected override void OnPaint( PaintEventArgs e )
    {
        using( var tempBmp = new Bitmap( ... ) )
        using( var g = Graphics.FromImage( tempBmp ) )
        {
            // draw to tempBmp
            e.Graphics.DrawImage( tempBmp, new Point( 0, 0 ) );
        }
    }
