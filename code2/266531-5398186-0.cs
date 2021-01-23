    public static class MyClass {
        // fore every process this value will be unique, but same for whole "life" of process
        private static readonly Guid unique = Guid.NewGuid();
        public static Guid Unique { get { return unique; } }
    }
