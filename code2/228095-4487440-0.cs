        public struct PACKET_DATA<T> where T : IDATA
        {
            public T data;
        }
        public interface IDATA { }
        public struct DATA_MESSAGE : IDATA
        {
            public string message;
        }
        public struct DATA_FILE : IDATA
        {
            public string fileName;
            public long fileSize;
        }
