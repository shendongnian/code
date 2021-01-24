    using System;
    using System.Net.WebSockets;
    using System.Threading.Tasks;
    using System.Linq;
    public class Program
      {
        public static async Task Main (string[] args)
        {
            string address="localhost"; //server address 
            int port=9011;
            ClientWebSocket socket=new ClientWebSocket();
            CancellationTokenSource src=new CancellationTokenSource();
            try
            {
                 await socket.ConnectAsync(new Uri($"ws://{address}:{port.ToString()}"));
                 Task receiveTask=Task.Run(async()=>await LoopAsync(socket),src.Token);
                 Console.ReadKey();
                 src.Cancel();
            }
            catch
            {
                return;
            }
           
        }
        public static Task LoopAsync(WebSocket socket){
            byte []buffer=new byte[1024];
            int receivedCount=0;
            while(true){
                WebSocketReceiveResult result=await socket.ReceiveAsync(new ArraySegment<byte>(buffer),CancellationToken.None);
                Console.WriteLine(Encoding.UTF8.GetString(buffer.Take(result.Count)));
                
            }
        }
      }
