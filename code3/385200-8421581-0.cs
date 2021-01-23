    [XmlRoot("table")]
    public class Table
    {
    	[XmlElement(typeof(Row), ElementName = "tr")]
    	public List<Row> Rows { get; set; }
    }
    
    public class Row
    {
    	[XmlElement(typeof(Cell), ElementName = "td")]
    	public List<Cell> Cells { get; set; }
    }
    
    public class Cell
    {
    	[XmlText(typeof(string))]
    	public string Value { get; set; }
    }
