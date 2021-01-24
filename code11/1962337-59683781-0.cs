     bool ComputePaths(ref NurbsCurve sprout, List<Curve> segments, List<Vector3d> nodes)
      {
        double threshold = 0.5;
        int counter = 0;
        while(true)
        {
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
              sprout = segmentsJoined[0].ToNurbsCurve();
    
              Vector3d c = sprout.PointAtStart - origin;
              if (c.Length > threshold)
              {
                sprout.Reverse();
              }
    
              for (int j = 0; j < nodes.Count; j++)
              {
                Vector3d d = sprout.PointAtEnd - new Point3d(nodes[j].X, nodes[j].Y, nodes[j].Z);
                if (d.Length < threshold)
                {
                  return true;
                }
              }
            }
            else
            {
              counter += 1;
              if(counter == segments.Count)
              {
                return false;
              }
            }
          }
        }
      }
