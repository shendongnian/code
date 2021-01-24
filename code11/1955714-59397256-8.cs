    public delegate void DataReceivedEventHandler(object data);
    public static class Transmitter
    {
        public static event DataReceivedEventHandler DataReceived;
        public static void TransmitData(object data)
        {
            DataReceived?.Invoke(data); // Raise the event.
        }
    }
