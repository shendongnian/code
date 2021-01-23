    public class FirstDataKindEventArgs : EventArgs
    {
        public FirstDataKindEventArgs(int parID, string parName, string parOtherInfo)
        {
            Id = parId; 
            Name = parName;
            OtherInfo = parOtherInfo;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string OtherInfo { get; set; }
    } 
    // plus other event arg definitions
    public interface IExchangeDataProvider
    {
        event EventHandler<FirstDataKindEventArgs> FirstDataKindReceived;
        event EventHandler<SecondDataKindEventArgs> SecondDataKindReceived;
        event EventHandler<ThirdDataKindEventArgs> ThirdDataKindReceived;       
    }
    public interface IExchangeDataReceiver
    {
        void ConnectDataProvider(IExchangeDataProvider Provider);
    }
