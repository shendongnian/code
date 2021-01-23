    public static Segment Closest_BruteForce(List<PointF> points)
    {
        PointF closest1;
        PointF closest2;
        float minDist = float.MaxValue;
        for(int x=0; x<points.Count; x++)
        {
            PointF P1 = points[x];
            for(int y = x + 1; y<points.Count; y++)
            {
                PointF P2 = points[y];
                float temp = LengthSquared(P1, P2);
                if(temp < minDist) 
                {
                   minDist = temp;
                   closest1 = P1;
                   closest2 = P2;
                }
            }
        }
        return new Segment(closest1, closest2);
    }
