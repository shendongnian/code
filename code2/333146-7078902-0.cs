    public class AppearsImmutableButIsntDeeplyImmutable
    {
        private readonly StringBuilder builder = new StringBuilder();
        public StringBuilder Builder { get { return builder; } }
    }
