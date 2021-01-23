    class SomeObject 
    {
      public int Id {get;set;}
      public List<RowInfo> ListRowInfo {get;set;}
    }
    
    class RowInfo
    {
      public List<Row> {get;set;}
    }
    class Row
    {
      public int RowData {get;set;}
    }
