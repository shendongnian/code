lang-cs
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace ExampleNamespace
{
    
    /* 
     * data class; encapsulates byte array data received from a client. 
     * in an actual implementation this might be a nice spot to put code 
     * that interprets bytes from the client in some way
     */
    public class Transmission
    {
        public IPEndPoint Client { get; set; }
        public byte[] Data { get; set; }
        public Transmission(IPEndPoint client, byte[] data)
        {
            Client = client;
            Data = data;
        }
    }
    public class Server
    {
        private UdpClient listener;
        /*
         * you probably want to make this a bounded collection to prevent the
         * collection from getting too big
         */
        private BlockingCollection<Transmission> dataReceived = new BlockingCollection<Transmission>();
        private bool receivePackets = true;
        private bool processData = true;
        private IPEndPoint groupEP;
        public Server(IPEndPoint listenAt)
        {
            listener = new UdpClient(listenAt);
            groupEP = listenAt;
        }
        public void Run()
        {
            ProcessData();
            ReceiveData();
        }
        public async void ReceiveData()
        {
            await Task.Run(() => {
                while (receivePackets)
                {
                    byte[] data = listener.Receive(ref groupEP);
                    dataReceived.Add(new Transmission(groupEP, data));
                }
            });
        }
        public async void ProcessData()
        {
            //you could run just a few of these to increase your processing 
            //speed without changing how things work
            await Task.Run(async () => {
                while (processData)
                {
                    //blocks until data is available
                    Transmission data = dataReceived.Take();
                    //do things with the data...
                    await Task.Delay(5000);
                }
            });
        }
    }
}
As stated, this example has some issues — if you want to actually implement this I highly recommend looking into making `dataReceived` a bounded blocking collection so you don't have to worry about memory issues. Also, it's generally useful to be able to shut down the whole process by passing a [CancellationToken][2] to your Take() and TryTake() calls, as well as any threads you create. However, the design itself should allow for easy multitasking in the event that processing clients becomes a performance problem.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.blockingcollection-1?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.8
