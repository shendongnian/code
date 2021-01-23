    [Test]
    public void Test_DetermineWindingDirection()
    {
    
        GraphicsPath path = new GraphicsPath();
    
        // Set up points collection
        PointF[] pts = new[] {new PointF(10, 60),
    				    new PointF(50, 110),
    				    new PointF(90, 60)};
        path.AddLines(pts);
      
        foreach(var point in path.PathPoints)
        {
       	    Console.WriteLine("X: {0}, Y: {1}",point.X, point.Y);
        }
    
        WindingDirection windingVal = DetermineWindingDirection(path.PathPoints);
        Console.WriteLine("Winding value: {0}", windingVal);
        Assert.AreEqual(WindingDirection.Clockwise, windingVal);
        path.Reverse();
        foreach(var point in path.PathPoints)
        {
       	    Console.WriteLine("X: {0}, Y: {1}",point.X, point.Y);
        }
    
        windingVal = DetermineWindingDirection(path.PathPoints);
        Console.WriteLine("Winding value: {0}", windingVal);
        Assert.AreEqual(WindingDirection.CounterClockWise, windingVal);
    }
    
    public enum WindingDirection
    {
        Clockwise,
        CounterClockWise
    }
    
    public static WindingDirection DetermineWindingDirection(PointF[] polygon)
    {
        // find a point in the middle
        float middleX = polygon.Average(p => p.X);
        float middleY = polygon.Average(p => p.Y);
        var pointInPolygon = new PointF(middleX, middleY);
        Console.WriteLine("MiddlePoint = {0}", pointInPolygon);
    
        double w = 0;
        var points = polygon.Select(point =>
                                        { 
                                            var newPoint = new PointF(point.X - pointInPolygon.X, point.Y - pointInPolygon.Y);
                                            Console.WriteLine("New Point: {0}", newPoint);
                                            return newPoint;
                                        }).ToList();
    
        for (int i = 0; i < points.Count; i++)
        {
            var secondPoint = i + 1 == points.Count ? 0 : i + 1;
            double X = points[i].X;
            double Xp1 = points[secondPoint].X;
            double Y = points[i].Y;
            double Yp1 = points[secondPoint].Y;
    
            if (Y * Yp1 < 0)
            {
                double r = X + ((Y * (Xp1 - X)) / (Y - Yp1));
                if (r > 0)
                    if (Y < 0)
                        w = w + 1;
                    else
                        w = w - 1;
            }
            else if ((Y == 0) && (X > 0))
            {
                if (Yp1 > 0)
                    w = w + .5;
                else
                    w = w - .5;
            }
            else if ((Yp1 == 0) && (Xp1 > 0))
            {
                if (Y < 0)
                    w = w + .5;
                else
                    w = w - .5;
            }
        }
        return w > 0 ? WindingDirection.ClockWise : WindingDirection.CounterClockwise;
    }
