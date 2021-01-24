        using (var cts = new CancellationTokenSource())
		{
			Task.Run(async () =>
			{
				try
				{
					await Task.Delay((int)comm.TimeoutMs, cts.Token);
					System.Diagnostics.Debug.WriteLine("Canceling async read");
					// If we make it this far, then the read as failed...cancel the async io
					// which will cause the bytesRead below to be 0.
					await _bluetoothStream.CancelIOAsync();
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
			}, cts.Token);
			var loadTask = _dataReader.LoadAsync(comm.ReceiveCount).AsTask();
			bytesRead = await loadTask;
			if (bytesRead > 0)
			{
				// SIgnal the delay task to cancel...
				cts.Cancel(true);
				if (bytesRead > comm.ReceiveCount)
					System.Diagnostics.Debug.WriteLine("Received too much!!");
				rxData = new byte[bytesRead];
				_dataReader.ReadBytes(rxData);
			}
		    else
		    {
			    System.Diagnostics.Debug.WriteLine("Received 0!");
		    }
	    }
