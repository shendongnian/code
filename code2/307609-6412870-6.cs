        [AttributeUsage(AttributeTargets.Class)] 
        public class LogFileAttribute: Attribute
        {
            readonly string path;
            public LogFileAttribute(string path)
            {
                this.path = path;
            }
            public string Path { get { return this.path; } }
        }
