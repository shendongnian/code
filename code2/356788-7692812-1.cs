    // Generated code
    public enum SetupTypeEnum
    {
      None,
      NewInstall,
      Modify,
      Upgrade,
      Uninstall
    }
    // End generated code
    public struct IntMappedEnum<T> where T : struct
    {
      public readonly int originalValue;
      public IntMappedEnum(T value)
      {
         originalValue = (int)Enum.ToObject(typeof(T), value);
      }
      public IntMappedEnum(int originalValue)
      {
         this.originalValue = originalValue;
      }
      public static implicit operator int(IntMappedEnum<T> value)
      {
         return 1 << value.originalValue;
      }
      public static implicit operator IntMappedEnum<T>(T value)
      {
         return new IntMappedEnum<T>(value);
      }
      public static implicit operator IntMappedEnum<T>(int value)
      {
         int log;
         for (log = 0; value > 1; value >>= 1)
            log++;
         return new IntMappedEnum<T>(log);
      }
      public static explicit operator T(IntMappedEnum<T> value)
      {
         T result;
         Enum.TryParse<T>(value.originalValue.ToString(), out result);
         return result;
      }
    }
    class Program
    {
      static void Main(string[] args)
      {
         SetupTypeEnum s = SetupTypeEnum.Uninstall;
         IntMappedEnum<SetupTypeEnum> c = s;
         int n = c;
         IntMappedEnum<SetupTypeEnum> c1 = n;
         SetupTypeEnum s1 = (SetupTypeEnum)c1;
         Console.WriteLine("{0} => {1} => {2}", s, n, s1);
      }
    }
