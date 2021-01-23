    enum SystemMetric
    {
      SM_CXSCREEN = 0,
      SM_CYSCREEN = 1,
    }
    [DllImport("user32.dll")]
    static extern int GetSystemMetrics(SystemMetric smIndex);
    int CalculateAbsoluteCoordinateX(int x)
    {
      return x * (65536 / GetSystemMetrics(SystemMetric.SM_CXSCREEN));
    }
    int CalculateAbsoluteCoordinateY(int y)
    {
      return y * (65536 / GetSystemMetrics(SystemMetric.SM_CYSCREEN));
    }
