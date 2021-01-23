    public class Directory
    {
        //...
        public IEnumerable<Object> Members
        {
            get
            {
                foreach (var directory in Directories)
                    yield return directory;
                foreach (var file in Files)
                    yield return file;
            }
        }
        //...
    }
