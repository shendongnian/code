c#
private static bool hasElapsed(ref Stopwatch sw, int total)
{
	return (sw.ElapsedMilliseconds > (long) total);
}
private static bool hasElapsed(ref Stopwatch sw, int total, out int remaining)
{
	remaining = (int) (((long) total) - sw.ElapsedMilliseconds);
	return (remaining < 0);
}
private static bool _TryPing(string strIpAddress, int intPort, int nTimeoutMsec)
{
	Stopwatch sw = Stopwatch.StartNew();
	do
	{
		try
		{
			using (TcpClient tcp = new TcpClient())
			{
				tcp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
				IAsyncResult ar = tcp.BeginConnect(strIpAddress, intPort, null, null);
				WaitHandle wh = ar.AsyncWaitHandle;
				try
				{
					int remaining;
					if (!hasElapsed(ref sw, nTimeoutMsec, out remaining))
					{
						if (wh.WaitOne(remaining))
						{
							tcp.EndConnect(ar);
							return true;
						}
					}
					tcp.Close(); 
				}
				finally
				{
					wh.Close();
				}
			}
		}
		catch
		{
		}
	}
	while (!hasElapsed(sw, nTimeoutMsec));
	return false;
}
