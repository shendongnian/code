    public static class PointFExtensions
    {
          private static Dictionary<PointF, float> _dict = new Dictionary<PointF, float>();
    
          public static void SetT(this PointF self, float t)
          {
             _dict.Add(self, t);
          }
    
          public static float GetT(this PointF self)
          {
            return _dict[self];
          }
    }
