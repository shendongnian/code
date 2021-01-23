    public abstract class Tile {
      public abstract int Number { get; }
      public sealed Tile Advance() {
        if (this is TileA) {
          return new TileB();
        else if (this is TileB) {
          return new TileC();
        }
      }
    }
