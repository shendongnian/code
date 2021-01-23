    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        double X1 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1); //X 
        double Y1 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(1); //Y
        
        double X2 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(2); //X
        double Y2 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(1); //Y
    
        double X3 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1); //X
        double Y3 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(2); //Y
    
        double disctanceX = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
        double disctanceY = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
    
        if (disctanceX < disctanceY)
        {
            chart1.Series[0].MarkerSize = (int)Math.Ceiling(disctanceX);
        }
        else
        {
            chart1.Series[0].MarkerSize = (int)Math.Ceiling(disctanceY);
        }
    }
