    public class MyStream : System.IO.Stream
    {
        public override bool CanRead  { get { return true  ; } }
        public override bool CanSeek  { get { return false ; } }
        public override bool CanWrite { get { return false ; } }
        public override long Length   { get { throw new NotImplementedException(); } }
        public override long Position {
                                        get { throw new NotImplementedException(); }
                                        set { throw new NotImplementedException(); }
                                      }
        public override int Read( byte[] buffer , int offset , int count )
        {
            int bytesRead = 0 ;
            if ( !initialized )
            {
                Initialize() ;
            }
            
            for ( int bytesRemaining = count ; !atEOF && bytesRemaining > 0 ; )
            {
                
                int frameRemaining = frameLength - frameOffset ;
                int chunkSize      = ( bytesRemaining > frameRemaining ? frameRemaining : bytesRemaining ) ;
                
                Array.Copy( frame , offset , frame , frameOffset , chunkSize ) ;
                
                bytesRemaining -= chunkSize ;
                offset         += chunkSize ;
                bytesRead      += chunkSize ;
                
                // read next frame if necessary
                if ( frameOffset >= frameLength )
                {
                    ReadNextFrame() ;
                }
                
            }
            
            return bytesRead ;
        }
        public override long Seek( long offset , System.IO.SeekOrigin origin ) { throw new NotImplementedException(); }
        public override void SetLength( long value )                           { throw new NotImplementedException(); }
        public override void Write( byte[] buffer , int offset , int count )   { throw new NotImplementedException(); }
        public override void Flush()                                           { throw new NotImplementedException(); }
        private byte[] frame       = null  ;
        private int    frameLength = 0     ;
        private int    frameOffset = 0     ;
        private bool   atEOF       = false ;
        private bool   initialized = false ;
        private void Initialize()
        {
            if ( initialized ) throw new InvalidOperationException() ;
            frame       = new byte[1024] ;
            frameLength = 0 ;
            frameOffset = 0 ;
            atEOF       = false ;
            initialized = true ;
            ReadNextFrame() ;
            return ;
        }
        private void ReadNextFrame()
        {
            //TODO: read the next (or first 1024-byte buffer
            //TODO: set the frame length to the number of bytes actually returned (might be less than 1024 on the last read, right?
            //TODO: set the frame offset to 0
            //TODO: set the atEOF flag if we've exhausted the data source ;
            return ;
        }
    }
