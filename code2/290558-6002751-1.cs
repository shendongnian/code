    protected override void OnPaint ( System.Windows.Forms.PaintEventArgs e )
    {
        if ( Enabled )
        {
            //use normal realization
            base.OnPaint (e);
            return;
        }
        //custom drawing
        using ( Brush aBruch = new SolidBrush( "YourCustomDisableColor" ) )
        {
            e.Graphics.DrawString( Text,Font, aBrush, ClientRectangle );
        }
    }
