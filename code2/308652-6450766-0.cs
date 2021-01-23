    public class SheetClass  
    {
        RangeWrapper cells;
        public RangeWrapper Cells { get; }
    
        public SheetClass(Worksheet _sheet)
        {
            cells = new RangeWrapper(_sheet.Cells);
        }
    }
  
    public class RangeWrapper 
    {
        private readonly Range cells;
        public Cell this[int x, int y]
        {
            get { return Cells[x-1, y-1]; }
        }
        public RangeWrapper(Range cells)
        {
            this.cells = cells;
        }
    }
