    bool ComputePaths(ref Curve sprout, List segments, List nodes)
    {
        double threshold = 0.5;
    
        for (int i = 0; i < segments.Count; i++)
        {
            Vector3d a = sprout.PointAtEnd - segments[i].PointAtStart;
            Vector3d b = sprout.PointAtEnd - segments[i].PointAtEnd;
    
            if (a.Length < threshold | b.Length < threshold)
            {
                Point3d origin = new Point3d();
                origin = sprout.PointAtStart;
                List<Curve> segmentsToJoin = new List<Curve>();
                segmentsToJoin.Add(sprout);
                segmentsToJoin.Add(segments[i]);
                Curve[] segmentsJoined = new Curve[1];
                segmentsJoined = Curve.JoinCurves(segmentsToJoin, threshold);
                sprout = segmentsJoined[0];
                Vector3d c = sprout.PointAtStart - origin;
                    
                if (c.Length > threshold)
                {
                    sprout.Reverse();
                }
    
                for (int j = 0; j < nodes.Count; j++)
                {
                    Vector3d d = sprout.PointAtEnd - nodes[j];
                    
                    if (d.Length < threshold)
                    {
                        return true;
                    }
                }
            }
        }
    
        return false;
    }
 
