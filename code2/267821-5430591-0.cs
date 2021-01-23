    private void chart1_MouseWhatever(object sender, MouseEventArgs e)
    {
        chartArea1.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
        chartArea1.CursorY.SetCursorPixelPosition(new Point(e.X, e.Y), true);
        double pX = chartArea1.CursorX.Position; //X Axis Coordinate of your mouse cursor
        double pY = chartArea1.CursorY.Position; //Y Axis Coordinate of your mouse cursor
    }
