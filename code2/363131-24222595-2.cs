    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        //get the PixelPosition of first Marker
        double X1 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1); //X 
        double Y1 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(1); //Y
        //get the PixelPosition of second Marker(X)
        double X2 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(2); //X
        double Y2 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(1); //Y
        //get the PixelPosition of second Marker(Y)
        double X3 = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1); //X
        double Y3 = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(2); //Y
        //Calculate the Distance by Pythagoras (c² = a² + b²)
        //=> a² = (X1 - X2)² && b² = (Y1-Y2)²
        double disctanceX = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
        double disctanceY = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
        
        //limit the marker at smaller value
        if (disctanceX < disctanceY)
        {
                                          //cut the decimals other routines are possible
            chart1.Series[0].MarkerSize = (int) Math.Ceiling(disctanceX);
        }
        else
        {
            chart1.Series[0].MarkerSize = (int) Math.Ceiling(disctanceY);
        }
    }
