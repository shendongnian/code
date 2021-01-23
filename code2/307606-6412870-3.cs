        [AttributeUsage(AttributeTargets.Class)] 
        public class LogFileAttribute: Attribute
        {
            string path;
            bool append;
            public LogFileAttribute(string path, bool append = false)
            {
                this.path = path;
                this.append = append;
            }
            public bool Append { get { return this.append; } }
            public string Path { get { return this.path; } }
        }
