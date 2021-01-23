    private void WriteMouseCoordinatesInWPFUnits()
    {
        POINT p;
        if (GetCursorPos(out p))
        {
            Point wpfPoint = ConvertPixelsToUnits(p.X, p.Y);
            System.Console.WriteLine(Convert.ToString(wpfPoint.X) + ";" + Convert.ToString(wpfPoint.Y));
        }
    }
