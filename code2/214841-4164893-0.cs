    private void chartTemperature_MouseMove(object sender, MouseEventArgs e)
    {
      using( Pen p = new Pen(Color.Red, 2)){
        if (isDrawing)
        {
          Graphics g = chartTemperature.CreateGraphics();    
          g.DrawLine(p, prevPoint, e.Location);
          prevPoint = e.Location;
          numOfMouseEvents = 0;              
        }
      }
    }
