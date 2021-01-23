        public class FrameworkFileSystem : IFileSystem
        {
            public Stream OpenWrite(string filename)
            {
                return File.OpenWrite(filename);
            }
            // etc
        }
