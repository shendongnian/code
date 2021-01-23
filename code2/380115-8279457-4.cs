	static Task QueueReadTask( TaskScheduler ts, int number )
	{
		Output.Write( "QueueReadTask( " + number + " )" );
		return Task.Factory.StartNew( () =>
			{
				Output.Write( "Opening file " + number + "." );
				FileStream fileStream = File.Open( "D:\\1KB.txt", FileMode.Open, FileAccess.Read, FileShare.Read );
				byte[] buffer = new byte[ 32 ];
				var tRead = Task<int>.Factory.FromAsync( fileStream.BeginRead, fileStream.EndRead, buffer, 0, 32, null );
				var tClose = tRead.ContinueWith( task =>
						{
							Output.Write( "Closing file " + number + ". Read " + task.Result + " bytes." );
							fileStream.Close();
						}
						, TaskScheduler.Default
					);
				tClose.Wait();
			}
			, CancellationToken.None
			, TaskCreationOptions.None
			, ts
		);
	}
