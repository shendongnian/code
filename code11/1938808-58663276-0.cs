    using System;
    using System.Net.Sockets;
    using System.Net;
	class Program {
		static void OnUpdateData(IAsyncResult result) {
			UdpClient socket = result.AsyncState as UdpClient;
			IPEndPoint source = new IPEndPoint(0, 0);
			byte[] message = socket.EndReceive(result, ref source);
			Console.WriteLine("Got " + message.Length + " bytes from " + source);
			// schedule the next receive operation once reading is done:
			socket.BeginReceive(new AsyncCallback(OnUpdateData), socket);
		}
		static void Main(string[] args) {
			UdpClient socket = new UdpClient(12345); 
			socket.BeginReceive(new AsyncCallback(OnUpdateData), socket);
            //send message with same program or use another program
			IPEndPoint target = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
			// send a couple of sample messages:
 			for (int num = 1; num <= 3; num++) {
				byte[] message = new byte[num];
				socket.Send(message, message.Length, target);
			}
			Console.ReadKey();
		}
	}
