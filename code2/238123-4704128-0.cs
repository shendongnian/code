    struct DoubleOrDate {
      public DateTime Date;
      public double GetDouble() {
        return Date.ToOADate();
      }
    }
