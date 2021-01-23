	private Socket _socket;
	private ArraySegment<byte> _buffer;
	public void StartReceive()
	{
		ReceiveAsyncLoop(null);
	}
	// Note that this method is not guaranteed (in fact
	// unlikely) to remain on a single thread across
	// async invocations.
	private void ReceiveAsyncLoop(IAsyncResult result)
	{
		try
		{
		    // This only gets called once - via StartReceive()
			if (result != null)
			{
				int numberOfBytesRead = _socket.EndReceive(result);
				if(numberOfBytesRead == 0)
				{
					OnDisconnected(null); // 'null' being the exception. The client disconnected normally in this case.
					return;
				}
				var newSegment = new ArraySegment<byte>(_buffer.Array, _buffer.Offset, numberOfBytesRead);
				// This method needs its own error handling. Don't let it throw exceptions unless you
				// want to disconnect the client.
				OnDataReceived(newSegment);
			}
			// Because of this method call, it's as though we are creating a 'while' loop.
			// However this is called an async loop, but you can see it the same way.
			_socket.BeginReceive(_buffer.Array, _buffer.Offset, _buffer.Count, SocketFlags.None, ReceiveAsyncLoop, null);
		}
		catch (Exception ex)
		{
			// Socket error handling here.
		}
	}
