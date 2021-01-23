    class XmlStream : FileStream
    {
        DateTime deadline;
        public XmlStream(string filename, TimeSpan timeout)
               : base(filename, FileMode.Open)
        {
            deadline = DateTime.UtcNow + timeout;
        }
        public override int Read(byte[] array, int offset, int count)
        {
            if (DateTime.UtcNow > deadline)
                throw new TimeoutException();
            return base.Read(array, offset, count);
        }
    }
