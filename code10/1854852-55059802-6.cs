    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        Axis ay = chart1.ChartAreas[0].AxisY;
        if (ay.Minimum == ay.ScaleView.Position) 
        { action1 }
        else
        { action2 }
    }
