    private void button1_Click( object sender, EventArgs e )
    {
        using( Font f = new Font( "Times New Roman", 22f ) )
        {
            pictureBox1.Image = CreateImage( "TEXT", pictureBox1.Size, f, Color.Black );
        }
    }
    
    Bitmap CreateImage( string text, Size imageSize, Font font, Color fontColor )
    {
        Bitmap image = new Bitmap( imageSize.Width, imageSize.Height );
        using( Graphics g = Graphics.FromImage( image ) )
        using( Brush brush = new SolidBrush( fontColor ) )
        {
            g.DrawString( text, font, brush, new PointF( 0, 0 ) );
        }
    
        return image;
    }
