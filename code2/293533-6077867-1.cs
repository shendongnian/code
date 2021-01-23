        public enum OperatingSystemFamily
        {
            Microsoft,
            linux,
            Mac
        }
        public class OperatingSystem
        {
            public string Name { get { return "WINNT"; } }
            public OperatingSystemFamily Family { get { return OperatingSystemFamily.Microsoft; } }
        }
