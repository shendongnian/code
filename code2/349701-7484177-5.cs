    public enum TileState { TileA, TileB, TileC };
    public class Tile {
      private TileState state = TileState.TileA; // initial state
      public int Number {
        get {
          switch (state) {
            case TileState.TileA: return 1;
            case TileState.TileB: return 2;
            ...
            default: return -1; // or throw exception
          }
        }
      }
      public void Advance() {
        switch (state) {
          case TileState.TileA: state = TileState.TileB; break;
          case TileState.TileA: state = TileState.TileC; break;
          ...
          default: // exception ?
        }
      }
    }
