    _chart.MouseClick += _chart_MouseClick;
    
    private void _chart_MouseClick(object sender, MouseButtonEventArgs e)
    {            
        var mousePos = e.GetPosition(_chart).Y;
        double axisPos = 0;
        bool isWithinYRange = false;
        foreach (AxisY ay in _chart.ViewXY.YAxes)
        {
            ay.CoordToValue((float)mousePos, out axisPos, true);
            if (axisPos >= ay.Minimum && axisPos <= ay.Maximum)
            {
                // Segment clicked, get the index via ay.SegmentIndex;
                isWithinYRange = true;
            }
        }
        if (!isWithinYRange)
        {
            // Not in any segment
        }
    }
