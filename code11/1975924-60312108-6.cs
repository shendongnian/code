    public enum CellType : byte { Land, Water, Ice }
    public class Grid {
        private readonly Random rng = new Random();
        private readonly int width, height;
        private readonly Agent?[,] agents;
        private readonly CellType[,] cells;  // TODO: init in constructor?
        private float temperature = 20;  // global temperature in Celsius
    
        // ...
        public CellType CellTypeAt(int x, int y) {
            CellType type = cells[x,y];
            if (type == CellType.Water && temperature < 0) return CellType.Ice;
            else return type;
        }
    }
