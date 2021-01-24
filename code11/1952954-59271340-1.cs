    internal static class ComponentBit
    {
        public static int bitCounter = 0;
    };
    public static class Component<T>
    {
        public static readonly int bit; // This is static, it has a value per type T
        static Component()
        {
            bit = ComponentBit.bitCounter++;
        }
        public static int GetBit()
        {
            // This method only accesses static members, it can be static
            // Thus, no instance of T is needed
            return bit;
        }
    }
