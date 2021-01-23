    using System;
    using System.IO;
    using System.Text;
    using log4net ;
    namespace ConsoleApplication22
    {
        public class Log4NetTextWriter : TextWriter, IDisposable
        {
            private static ILog log = log4net.LogManager.GetLogger( typeof(Log4NetTextWriter) ) ;
        
            #region properties
        
            private StringBuilder buffer { get ; set ; }
        
            public override Encoding Encoding
            {
                get
                {
                    // since this TextWrite is writing to log4net, we have no idea what the final encoding might be.
                    // It all depends on the log4net configuration: tthe appender or appenders that wind up handling the logged message
                    // determine the final encoding.
                    //
                    // Might make more sense to return Encoding.UTF8 though, just to return something.
                    throw new NotImplementedException() ;
                }
            }
        
            #endregion properties ;
        
            public override void Flush()
            {
                if ( this.buffer != null && this.buffer.Length > 0 )
                {
                    this.WriteLine() ;
                }
                return ;
            }
        
            public override void Close()
            {
                base.Close();
            }
        
            protected override void Dispose( bool disposing )
            {
                this.Flush() ;
                base.Dispose( disposing );
            }
        
            #region public constructors
            public Log4NetTextWriter() : this( null )
            {
                return ;
            }
            public Log4NetTextWriter( IFormatProvider formatProvider ) : base( formatProvider )
            {
                this.buffer = new StringBuilder() ;
            }
            #endregion public constructors
        
            #region public Write() overloads
            public override void Write( bool value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( char value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( char[] buffer )
            {
                this.buffer.Append( buffer ) ;
                return ;
            }
            public override void Write( char[] buffer , int index , int count )
            {
                this.buffer.Append( buffer , index , count ) ;
                return ;
            }
            public override void Write( decimal value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( double value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( float value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( int value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( long value )
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write(object value)
            {
                this.buffer.Append( value ) ;
                return ;
            }
            public override void Write( string format , object arg0 )
            {
                this.buffer.AppendFormat( this.FormatProvider , format , arg0 ) ;
                return ;
            }
            public override void Write( string format , object arg0 , object arg1 )
            {
                this.buffer.AppendFormat( this.FormatProvider , format , arg0 , arg1 ) ;
                return ;
            }
            public override void Write( string format , object arg0 , object arg1 , object arg2 )
            {
                this.buffer.AppendFormat( this.FormatProvider , format , arg0 , arg1 , arg2 );
                return ;
            }
            public override void Write( string format , params object[] arg )
            {
                this.buffer.AppendFormat( this.FormatProvider , format , arg ) ;
                return ;
            }
            public override void Write( string value )
            {
                 this.buffer.Append( value );
                return ;
            }
            public override void Write( uint value )
            {
                this.buffer.Append( value );
                return ;
            }
            public override void Write( ulong value )
            {
                this.buffer.Append( value );
                return ;
            }
            public override void WriteLine()
            {
                string logMessage = this.buffer.ToString() ;
                this.buffer.Length = 0 ;
                log.Info( logMessage ) ;
                return ;
            }
        
            #endregion public Write() overloads
        
            #region public WriteLine() overloads
        
            public override void WriteLine( bool value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( char value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( char[] buffer )
            {
                this.Write( buffer ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( char[] buffer , int index , int count )
            {
                this.Write( buffer , index , count ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( decimal value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( double value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( float value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( int value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( long value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( object value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( string format , object arg0 )
            {
                this.Write( format , arg0 ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( string format , object arg0 , object arg1 )
            {
                this.Write( format , arg0 , arg1 ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( string format , object arg0 , object arg1 , object arg2 )
            {
                this.Write( format , arg0 , arg1 , arg2 ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( string format , params object[] arg )
            {
                this.Write( format , arg ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( string value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( uint value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
            public override void WriteLine( ulong value )
            {
                this.Write( value ) ;
                this.WriteLine() ;
                return ;
            }
        
            #endregion public WriteLine() overloads
        
        }
    }
