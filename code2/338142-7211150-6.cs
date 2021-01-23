	using System;
	using System.Net.Sockets;
	using System.Net;
	using System.Threading;
	namespace Test2
	{
		class MainClass
		{
			public static void Main (string[] args)
			{		
				var t = new Thread(Read) { IsBackground = true };
				t.Start();
				Thread.Sleep(300);
				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(new IPEndPoint(IPAddress.Loopback, 1234));
				for(var i = 0; i < 10; i++)
				{
					Console.WriteLine(socket.Send(new [] {(byte) 0x12}));
				}
			}
			
			public static void Read()
			{
				var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				s.Bind(new IPEndPoint(IPAddress.Loopback, 1234));
				s.Listen(1);
				var accepted = s.Accept();
				while(true)
				{
					accepted.Receive(new byte[1]);
				}
			}
		}
	}
