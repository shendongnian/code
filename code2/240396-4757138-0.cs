    class Soil
    {
      public Soil(double anglePhi, double angleDelta)
      {
          AnglePhi = anglePhi;
          AngleDelta = angleDelta;
      }
    
      public double AnglePhi { get; private set; }
      public double AngleDelta { get; private set; }
    }
