    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        var ca = chart1.ChartAreas[0];
        Axis ay = ca.AxisY;
        if (ay.Minimum != ay.ScaleView.Position) 
        { action1 }
        else
        { action2 }
    }
