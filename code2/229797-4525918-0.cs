        public interface IFileSystem
        {
            Stream OpenWrite(string filename);
            TextReader OpenText(string filename);
            // etc
        }
