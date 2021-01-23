	public class Messenger
	{
		private readonly TcpClient client;
		private readonly NetworkStream stream;
		public IPEndPoint RemoteEndPoint { get { return (IPEndPoint) client.Client.RemoteEndPoint; } }
		public Messenger( TcpClient client )
		{
			this.client = client;
			stream = client.GetStream();
		}
		#region Send and Receive
		public TResponse SendReceive<TRequest, TResponse>( TRequest request ) where TRequest : Message where TResponse : Message
		{
			Send( request );
			return Receive<TResponse>();
		}
		public void Send<TRequest>( TRequest request ) where TRequest : Message
		{
			using( var ms = new MemoryStream())
			{
				Serializer.SerializeWithLengthPrefix( ms, request, PrefixStyle.Fixed32 );
				stream.Write( ms.GetBuffer(), 0, (int) ms.Length );
				stream.Flush();
			}
		}
		public TResponse Receive<TResponse>() where TResponse : Message
		{
			try
			{
				return GetMessage<TResponse>();
			}
			catch (Exception ex)
			{
				if (ex is IOException || ex is InvalidOperationException)
				{
					stream.Dispose();
				}
				throw;
			}
		}
		#endregion
		#region Helpers
		private TMessage GetMessage<TMessage>() where TMessage : Message
		{
			int messageLength = BitConverter.ToInt32(GetBytes(stream, 4), 0);
			byte[] data = GetBytes(stream, messageLength);
			using (var ms = new MemoryStream(data))
			{
				return Serializer.Deserialize<TMessage>(ms);
			}
		}
		private static byte[] GetBytes(NetworkStream stream, int length)
		{
			int bytesRequired = length;
			int bytesRead = 0;
			var bytes = new byte[length];
			do
			{
				while( !stream.DataAvailable )
					Thread.Sleep( 100 );					
				int read = stream.Read(bytes, bytesRead, bytesRequired);
				bytesRequired -= read;
				bytesRead += read;
			}
			while (bytesRequired > 0);
			return bytes;
		}
		#endregion
	}
