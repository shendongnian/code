    public abstract class Tile {
      public abstract int Number { get; }
      public abstract Tile Advance();
    }
    public class TileA : Tile {
      public override int Number { get { return 1; } }
      public override Tile Advance() { return new TileB(); }
    }
    public class TileB : Tile {
      public override int Number { get { return 2; } }
      public override Tile Advance() { return new TileC(); }
    }
    public class TileC : Tile { ... }
