    public static Strings {
        private readonly string MemoryUsageTest;
        static Strings() {
    #if DEBUG
            int size = 104000000;
            var text = "abcdefghijklmnopqrstuvwxyz";
            var sb = new StringBuilder(size);
            for (int i = 0; i < size / text.Length; ++i) {
                sb.Append(text);
            }
            MemoryUsageTest = sb.ToString();
    #endif
        }
    }
