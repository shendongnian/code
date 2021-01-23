	public class IPC : IDisposable
	{
		public IPC(string pipeName)
		{
			Stream = new NamedPipeServerStream(pipeName,
			                                   PipeDirection.InOut,
			                                   1,
			                                   PipeTransmissionMode.Byte,
			                                   PipeOptions.Asynchronous);
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			           {
			           	try
			           	{
			           		Stream.EndWaitForConnection(ar);
			           	}
			           	catch (ObjectDisposedException)
			           	{
			           		return;
			           	}
			           	var buffer = new byte[2000];
			           	var length = Stream.Read(buffer, 0, buffer.Length);
			           	var message = new byte[length];
			           	Array.Copy(buffer, message, length);
			           	if (MessageReceived != null)
			           		MessageReceived(message);
			           	Stream.Disconnect();
			           	// ReSharper disable AccessToModifiedClosure
			           	Stream.BeginWaitForConnection(callback, null);
			           	// ReSharper restore AccessToModifiedClosure
			           };
			Stream.BeginWaitForConnection(callback, null);
		}
		private NamedPipeServerStream Stream
		{
			get;
			set;
		}
		#region IDisposable Members
		public void Dispose()
		{
			if (Stream != null)
				Stream.Dispose();
		}
		#endregion
		public static void SendMessage(string pipeName, byte[] message)
		{
			using (var client = new NamedPipeClientStream(".", pipeName))
			{
				client.Connect();
				client.Write(message, 0, message.Length);
				client.Close();
			}
		}
		~IPC()
		{
			Dispose();
		}
		public event MessageHandler MessageReceived;
	}
