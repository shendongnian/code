        public struct PACKET_DATA
        {
            public IData data;
            public T GetData<T>() where T : IDATA
            {
               return (T)data;
            }
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
    PACKET_DATA packetData = new PACKET_DATA();
    packetData.data = new DATA_MESSAGE();
    var message = packetData.GetData<DATA_MESSAGE>().message;
