    [Serializable()]
    [TypeConverter(typeof(SizeRangeConverter))]
    public struct SizeRange {
      private Byte? _min;
      private Byte? _max;
      public SizeRange(Byte? min, Byte? max) {
        _min = min;
        _max = max;
      }
      public Byte? Minimum {
        get { return _min; }
        set { _min = value; }
      }
      public Byte? Maximum {
        get { return _max; }
        set { _max = value; }
      }
      public override bool Equals(object obj) {
        if (obj is SizeRange)
          return ((SizeRange)obj).Minimum == this.Minimum && ((SizeRange)obj).Maximum == this.Maximum;
        else
          return false;
      }
      public override int GetHashCode() {
        return this.Minimum.GetValueOrDefault() ^ this.Maximum.GetValueOrDefault();
      }
      public override string ToString() {
        string minValue = this.Minimum == null ? "?" : this.Minimum.ToString();
        string maxValue = this.Maximum == null ? "?" : this.Maximum.ToString();
        return minValue + "," + maxValue;
      }
      public static Boolean operator ==(SizeRange sr1, SizeRange sr2) {
        return (sr1.Minimum == sr2.Minimum && sr1.Maximum == sr2.Maximum);
      }
      public static Boolean operator !=(SizeRange sr1, SizeRange sr2) {
        return !(sr1 == sr2);
      }
    }
