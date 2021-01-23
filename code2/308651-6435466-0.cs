    class SheetWrapper
    {
        private readonly Sheet sheet;
    
        public SheetWrapper(Sheet sheet) { this.sheet = sheet; }
    
        public object this[int row, int column]
        {
            get { return sheet.Cells[row, column].Value; } // add null checks, etc
            set { sheet.Cells[row, column].Value = value; }
        }
    }
