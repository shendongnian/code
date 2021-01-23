    interface ICell
    {
       public int Population { get; set; }
       public Color Color { get; set; }
    }
    private class CellMap
    {
        private ushort[,] populationData;
        private byte[,] colorData;
        public ICell this[int x, int y] 
        {
            get { return new Cell(this, x, y); }
        }
    
        private sealed class Cell : ICell
        {
            private CellMap map;
            private int x;
            private int y;
            internal Cell(CellMap map, int x, int y)
            {
                this.map = map; // etc
            }
            public int Population  
            {
                get { return this.map.populationData[this.x, this.y]; } 
                set { this.map.populationData[this.x, this.y] = (ushort) value; } 
            }
