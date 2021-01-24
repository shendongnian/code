    using OneOf; // https://github.com/mcintyre321/OneOf
    using Run = OneOf<String,Span<Char>,IEnumerable<Char>>;
    public class CompositeString
    {
        private readonly List<Run> runs = new List<Run>();
        public void Add( String str ) => this.runs.Add( str );
        public void Add( Span<Char> span ) => this.runs.Add( span );
        public void Add( IEnumerable<Char> chars ) => this.runs.Add( chars ); 
        public void WriteTo( TextWriter wtr )
        {
            foreach( Run run in this.runs )
            {
                run.Switch(
                    ( String s ) => wtr.Write( s ),
                    ( Span<Char> span ) =>
                    { // Span<T> doesn't implement IEnumerable<T>, but you can still use it with a `foreach`:
                        foreach( Char c in span ) wtr.Write( c );
                    },
                    ( IEnumerable<Char> chars ) =>
                    {
                        foreach( Char c in chars ) wtr.Write( c );
                    },
                );
            }
        }
        public override void ToString()
        {
            using( StringWriter wtr = new StringWriter() )
            {
                this.WriteTo( wtr );
                return wtr.ToString();
            }
        }
    }
