	int bySize = 0;
	try
	{
		bySize = info.Socket.EndReceive(result);
	}
	catch (Exception ex)
	{
		Console.WriteLine("Error from client {0}: {1}", info.client, ex.Message);
		return;
	}
	if (bySize <= 0)
		return;
		
