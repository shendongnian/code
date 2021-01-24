    public class ImageRewriteCollection
    {
        private ConcurrentDictionary<(int id, int width, int height), string> imageRewrites
            = new ConcurrentDictionary<(int id, int width, int height), string>();
        public bool TryAdd(int id, int width, int height, string path)
            => imageRewrites.TryAdd((id, width, height), path);
        public bool TryGetValue(int id, int width, int height, out string path)
            => imageRewrites.TryGetValue((id, width, height), out path);
    }
