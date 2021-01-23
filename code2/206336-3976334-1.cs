    class UnitSystem
    {
      public enum Type
      {
        Metric,
        Imperial
      }
      public static DistanceUnit[] GetUnits(Type type)
      {
        switch (type)
        {
          case Type.Metric:
            return new DistanceUnit[] {
              DistanceUnit.Millimeter,
              DistanceUnit.Centimeter,
              DistanceUnit.Meter,
              DistanceUnit.Kilometer
            }
          case Type.Imperial:
            return new DistanceUnit[] {
              DistanceUnit.Inch,
              DistanceUnit.Foot,
              DistanceUnit.Yard,
              DistanceUnit.Mile
            }
        }
      }
      public static Type GetType(DistanceUnit unit)
      {
        switch (unit)
        {
          case DistanceUnit.Millimeter:
          case DistanceUnit.Centimeter:
          case DistanceUnit.Meter:
          case DistanceUnit.Kilometer:
            return Type.Metric;
          case DistanceUnit.Inch:
          case DistanceUnit.Foot:
          case DistanceUnit.Yard:
          case DistanceUnit.Mile:
            return Type.Imperial;
        }
      }
    }
