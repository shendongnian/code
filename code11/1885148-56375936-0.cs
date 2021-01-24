	static class NetworkPrinter
	{
		const ushort tcpPort = 31337;
		const string sEOL = "\r\n";
		/// <summary>Send a single job to the printer.</summary>
		static async Task sendLabel( Stream stream, string what, CancellationToken ct )
		{
			byte[] toSend = Encoding.ASCII.GetBytes( sEOL + what );
			await stream.WriteAsync( toSend, 0, toSend.Length, ct );
			await stream.FlushAsync();
		}
		/// <summary>Connect to a network printer, send a batch of jobs reporting progress, disconnect.</summary>
		public static async Task printLabels( string ip, string[] labels, Action<double> progress, CancellationToken ct )
		{
			IPAddress address = IPAddress.Parse( ip );
			double progressMul = 1.0 / labels.Length;
			using( var tc = new TcpClient() )
			{
				await tc.ConnectAsync( address, tcpPort );
				Stream stream = tc.GetStream();
				for( int i = 0; i < labels.Length; )
				{
					ct.ThrowIfCancellationRequested();
					await sendLabel( stream, labels[ i ], ct );
					i++;
					progress( i * progressMul );
				}
			}
		}
		/// <summary>Send multiple batches to multiple printers, return true of all of them were good.</summary>
		public static async Task<bool> printBatches( LabelBatch[] batches )
		{
			await Task.WhenAll( batches.Select( a => a.print( CancellationToken.None ) ) );
			return batches.All( a => a.completed );
		}
	}
	/// <summary>A batch of labels to be printed by a single printer.</summary>
	/// <remarks>Once printed, includes some status info.</remarks>
	class LabelBatch
	{
		readonly string ip;
		readonly string[] labels;
		public bool completed { get; private set; } = false;
		public Exception exception { get; private set; } = null;
		public LabelBatch( string ip, IEnumerable<string> labels )
		{
			this.ip = ip;
			this.labels = labels.ToArray();
		}
		/// <summary>Print all labels, ignoring the progress. This method doesn't throw, returns false if failed.</summary>
		public async Task<bool> print( CancellationToken ct )
		{
			completed = false;
			exception = null;
			try
			{
				await NetworkPrinter.printLabels( ip, labels, d => { }, ct );
				completed = true;
			}
			catch( Exception ex )
			{
				exception = ex;
			}
			return completed;
		}
	}
