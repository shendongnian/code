    public class RowObject : IEnumerable<double?>
    {
      private double?[] vars { get; set; }
      IEnumerator<double?> IEnumerable<double?>.GetEnumerator()
      {
        foreach ( var value in vars )
          yield return value;
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        foreach ( var value in vars )
          yield return value;
      }
      private void CheckIndex(int index, int min, int max)
      {
        if ( index < min || index > max )
          throw new ArgumentOutOfRangeException("Index", $"Must be between {min} and {max}");
      }
      public double? this[int index]
      {
        get
        {
          CheckIndex(index, 0, vars.Length);
          return vars[index];
        }
        set
        {
          CheckIndex(index, 0, vars.Length);
          vars[index] = value;
        }
      }
      public RowObject(int capacity)
      {
        vars = new double?[capacity];
      }
    }
