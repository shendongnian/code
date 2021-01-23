    public enum CompressionType
    {
        Deflate,
        GZip
    }
	/// <summary>
	/// Provides GZip or Deflate compression, with further handling for the fact that
	/// .NETs GZip and Deflate filters don't play nicely with chunked encoding (when
	/// Response.Flush() is called or buffering is off.
	/// </summary>
	public class WebCompressionFilter : Stream
	{
	    private Stream _compSink;
	    private Stream _finalSink;
		public WebCompressionFilter(Stream stm, CompressionType comp)
		{
		    switch(comp)
		    {
		        case CompressionType.Deflate:
		            _compSink = new DeflateStream((_finalSink = stm), CompressionMode.Compress);
		            break;
		        case CompressionType.GZip:
		            _compSink = new GZipStream((_finalSink = stm), CompressionMode.Compress);
		            break;
		    }
		}
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override void Flush()
        {
            //We do not flush the compression stream. At best this does nothing, at worse it
            //loses a few bytes. We do however flush the underlying stream to send bytes down the
            //wire.
            _finalSink.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _compSink.Write(buffer, offset, count);
        }
        public override void WriteByte(byte value)
        {
            _compSink.WriteByte(value);
        }
        public override void Close()
        {
            _compSink.Close();
            _finalSink.Close();
            base.Close();
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _compSink.Dispose();
                _finalSink.Dispose();
            }
            base.Dispose(disposing);
        }
    }
