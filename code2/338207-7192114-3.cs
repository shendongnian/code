    public Point GunLocation
    {
        get
        {
            double x = (double) this.GetValue(Canvas.LeftProperty) + 21;
            double y = (double) this.GetValue(Canvas.TopProperty) + 17;
            return new Point(x, y);
        }
    }
