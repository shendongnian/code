    public class FileProcessor
    {
        private readonly Queue<string> files = new Queue<string>();
        public void EnqueueFile(string path)
        {
            files.Enqueue(path);
        }
    }
