    class Table
    {
    	public IEnumerable<Row> Rows { get; set; }
    }
    class Row
    {
    	public IEnumerable<Cell> Cells { get; set; }
    }
    class Cell { }
