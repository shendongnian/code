    public static class Component
    {
        internal static int bitCounter = 0;
        public static int GetBit<T>()
            where T : struct // We only accept structs here
        {
            return Component<T>.bit;
        }
        public static int GetBit<T>(this ref T value)
            where T : struct // We only accept structs here
        {
            // This is an extension method.
            // It will appear as a method on any valid T (which is all structs)
            // The type T will be infered from the instance.
            // Passing the struct as a reference to avoid a copy
            _ = value; // discard value
            return GetBit<T>();
        }
    };
    internal static class Component<T>
        where T : struct // We only accept structs here
    {
        internal static readonly int bit;
        static Component()
        {
            bit = Component.bitCounter++;
        }
    }
