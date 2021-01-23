    public sealed class Country
    {
        // initialize appropriately in the constructor...
        private readonly int[] m_Values;
        private readonly string m_Name;
        // make the constructor private so that only this class can set up instances
        private Country( string name, int[] codes ) { ... }
    
        public static Country US = new Country("United States", new[]{ 1,2 } );
        public static Country Canada = new Country("Canada", new[] {3,4} );
        public static Country FromCode( int code ) { ... }
        public override string ToString() { return m_Name; }
        // ... etc...
    }
