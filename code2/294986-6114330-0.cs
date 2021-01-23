    public static int Abs(int value)
    {
      if (value >= 0)
        {
          return value;
        }
      return AbsHelper(value);
    }
    private static int AbsHelper(int value)
    {
      if (value == -2147483648)
      {
        throw new OverflowException(Environment.GetResourceString("Overflow_NegateTwosCompNum"));
      }
      return -value;
    }
