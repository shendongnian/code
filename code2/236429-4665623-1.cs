    struct Mutable : IDisposable
    {
        public int Field;
        public void SetField( int value ) { Field = value; }
        public void Dispose() { }
    }
    class Program
    {
        protected static readonly Mutable xxx = new Mutable();
    
        static void Main( string[] args )
        {
            //not allowed by compiler
            //xxx.Field = 10;
    
            xxx.SetField( 10 );
    
            //prints out 0 !!!! <--- I do think that this is pretty bad
            System.Console.Out.WriteLine( xxx.Field );
    
            using ( var m = new Mutable() )
            {
                // This results in a compiler error.
                //m.Field = 10;
                m.SetField( 10 );
    
                //This prints out 10 !!!
                System.Console.Out.WriteLine( m.Field );
            }
    
            
    
            System.Console.In.ReadLine();
        }
    
    
