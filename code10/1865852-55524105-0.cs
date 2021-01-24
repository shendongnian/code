    TaskCompletionSource<ErrorCode> source = null;
	private void Sender_Recieve(object sender, ErrorCode e)
	{
	    source.SetResult(e);
	}
	public async Task<ErrorCode> SendPacketAsync(Packet packet)
	{
		source = new TaskCompletionSource<ErrorCode>();
		//send packet
        return await source.Task;
	}
