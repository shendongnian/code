	class StreamCopier: IProgress
	{
		private Stream _source;
		private Stream _destination;
		
		public StreamCopier(Stream source, Stream destination)
		{
			_source = source;
			_destination = destination;
		}
		
		public void WriteAll()
		{
			int b;
			while ((b = _source.ReadByte()) != -1)
			{
				_destination.WriteByte((byte)b);
				EventHandler tmp = ProgressChanged;
				if (tmp != null) tmp(this, EventArgs.Empty);
			}
		}
		
		public event EventHandler ProgressChanged;
		
		public int ProgressTarget {
			get { return (int)_source.Length; }
		}
		
		
		public int CurrentProgress {
			get { return (int)_destination.Position; }
		}
	}
