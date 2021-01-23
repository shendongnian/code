    public class SomeObject 
    {
      public List<Layer> Layers {get;set;}
    }
    public class Layer
    {
      public int Id {get;set;}
      public List<RowInfo> RowInfos {get;set;}
    }
    
    public class RowInfo
    {
      public List<Row> Rows {get;set;}
    }
    public class Row
    {
      public int RowData {get;set;}
    }
