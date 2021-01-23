    class UnitSystem
    {
      public static DistanceUnit[] Imperial()
      {
        return new DistanceUnit[] {
          DistanceUnit.Inch,
          DistanceUnit.Foot,
          DistanceUnit.Yard,
          DistanceUnit.Mile
        }
      }
      public static DistanceUnit[] Metric()
      {
        return new DistanceUnit[] {
          DistanceUnit.Millimeter,
          DistanceUnit.Centimeter,
          DistanceUnit.Meter,
          DistanceUnit.Kilometer
        }
      }
    }
