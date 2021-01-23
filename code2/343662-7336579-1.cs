    public static class MathLibExt {
      public static double FloorCap(this double value, double floor, double cap) {
        return Math.Min(Math.Max(floor, value), cap);
      }
    }
    
    // call like
    var value = 25.0;
    var capped = value.FloorCap(1, 10);
