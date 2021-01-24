    [Guid("0135bc5c-b248-444c-94b9-b0b4577f5a1a")]
    [ProgId("MyComponent.TwoWay")]
    [ComVisible(true)]
    public class TwoWay
    {
        public void Initialize(string IPAddress, long Port, long MaxPacketSize)
        {
            Console.WriteLine(IPAddress);
        }
        // other methods...
    }
