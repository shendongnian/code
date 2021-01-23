    class Uploader
	{
		/// <summary>Thread-safe flag to ensure that a packet isn't currently sending</summary>
		private volatile bool isPacketSending = false;
		
		/// <summary>
		/// HTTP Posts a stream to a web address with a maximum bytes per second until the file is uploaded
		/// </summary>
		/// <param name="address">The web address to post the file to</param>
		/// <param name="requestBody">The request body to stream at a maximum speed</param>
		/// <param name="bytesPerSecond">The maximum number of bytes to send every second</param>
		/// <returns>Returns an observable sequence of the bytes read so far</returns>
		public IObservable<long> PostStreamThrottledAsync(Uri address, Stream requestBody, int bytesPerSecond)
		{
			if (!requestBody.CanRead)
			{
				throw new InvalidOperationException("Request body stream cannot be read from");
			}
		
			return Observable.Using(
				() =>
					{
						var client = new WebClient();
						return client.OpenWrite(address);
					},
				outputStream => Observable.Return(0L).Concat(Observable.Interval(TimeSpan.FromSeconds(1)))
							.TakeWhile(tick => SendPacket(requestBody, outputStream, bytesPerSecond) != 0)
							.Select(_ => requestBody.Position));
		}
		
		
		/// <summary>
		/// Sends a packet up to the maximum bytes specified
		/// </summary>
		/// <param name="requestBody">The stream to read from</param>
		/// <param name="output">The stream to write to</param>
		/// <param name="bytesPerSecond">The number of bytes to send</param>
		/// <returns>Returns the number of bytes actually sent; zero if at end of stream; -1 if we are exceeding throughput capacity.</returns>
		private int SendPacket(Stream requestBody, Stream output, int bytesPerSecond)
		{
			if (isPacketSending)
			{
				return -1;
			}
		
			try
			{
				isPacketSending = true;
				var buffer = new byte[bytesPerSecond];
				var bytesRead = requestBody.Read(buffer, 0, bytesPerSecond);
				if (bytesRead != 0)
				{
					output.Write(buffer, 0, bytesRead);
				}
		
				return bytesRead;
			}
			finally
			{
				isPacketSending = false;
			}
		}
	}
