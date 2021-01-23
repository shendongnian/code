    struct Soil
    {
      private readonly double anglePhi;
      private readonly double angleDelta;
    
      public Soil(double phi, double delta) {
        this.anglePhi = phi;
        this.angleDelta = delta; 
      }
      
      public double AnglePhi { get { return anglePhi; } }
      public double AngleDelta { get { return angleDelta; } }
    }
