    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {    
      if (action2)
      {
        myPointList.Add( e.Location );
        panel1.Invalidate(); //force a repaint
      }
    }
    
    private void panel1_Paint( object sender, PaintEventArgs e )
    {
        e.Graphics.DrawLines( Pens.Black, myPointList );
    }
