    class Coordinate : Tree<Coordinate>
    {
        Coordinate(Coordinate parent) : this(parent) { }
        static readonly Coordinate Root = new Coordinate(null);
        // lots more code handling coordinate systems
    }
