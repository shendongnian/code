    public interface IDataType
    {
    }
    public struct PACKET_DATA
    {
        public Command command;
        public IDataType data;  
    };
    public struct DATA_MESSAGE : IDataType
    {
        public string message;
    };
    public struct DATA_FILE : IDataType
    {
        public string fileName;
        public long fileSize;       
    };
