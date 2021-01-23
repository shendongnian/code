    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    
    class SocketServer
    {
    
    	public static void Main()
    	{
    
    		StreamReader streamReader;
    		NetworkStream networkStream;
    
    		TcpListener tcpListener = new TcpListener(5555);
    		tcpListener.Start();
    
    		Console.WriteLine("The Server has started on port 5555");
    		Socket serverSocket = tcpListener.AcceptSocket();
    
    		try
    		{
    			Console.WriteLine("Client connected");
    			networkStream = new NetworkStream(serverSocket);
    
    			streamReader = new StreamReader(networkStream);
    			while (true)
    			{
    				var line = streamReader.ReadLine();
    				Console.WriteLine(line);
    				//echoing
    				var buffer = Encoding.ASCII.GetBytes(line);
    				networkStream.Write(buffer, 0, buffer.Length);
    			}
    
    			serverSocket.Close();
    			Console.Read();
    		}
    
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex);
    		}
    	}
    }
