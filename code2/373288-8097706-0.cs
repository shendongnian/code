    public class AppendTextFilter : Stream
    {
        private Stream Filter { get; set; }
        private string Text { get; set; }
        private bool TextWritten { get; set; }
        public AppendTextFilter( Stream filter, string text )
        {
            this.Filter = filter;
            this.Text = text;
        }
        public override bool CanRead { get { return Filter.CanRead; } }
        public override bool CanSeek { get { return Filter.CanSeek; } }
        public override bool CanWrite { get { return Filter.CanWrite; } }
        public override void Flush()
        {
            if (!TextWritten)
            {
                var bytes = Encoding.UTF7.GetBytes( Text );
                Filter.Write( bytes, 0, bytes.Length );
                TextWritten = true;
            }
            Filter.Flush();
        }
        public override long Length { get { return Filter.Length + Text.Length; } }
        public override long Position
        {
            get
            {
                return Filter.Position;
            }
            set
            {
                Filter.Position = value;
            }
        }
        public override int Read( byte[] buffer, int offset, int count )
        {
            return Filter.Read( buffer, offset, count );
        }
        public override long Seek( long offset, SeekOrigin origin )
        {
            return Filter.Seek( offset, origin );
        }
        public override void SetLength( long value )
        {
            Filter.SetLength( value );
        }
        public override void Write( byte[] buffer, int offset, int count )
        {
            Filter.Write( buffer, offset, count );
        }
    }
      
