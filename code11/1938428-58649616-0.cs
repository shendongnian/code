    public class FileSize
    {
        private readonly double _bytes;
        public double Bytes => _bytes;
        public double Kb => _bytes / 1024;
        public double Mb => Kb / 1024;
        public double Gb => Mb / 1024;
        public FileSize(long size)
        {
            _bytes = size * 1.0
        }
    }
    // Usage
    var size = new FileSize(120000);
    size.Bytes; // 120000
    size.Kb; // 120
    size.Mb; // 0.12
