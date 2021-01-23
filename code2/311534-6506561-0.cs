    class Row {
       public int id {get;set;}
       public object[] cell {get;set;}
    }
    
    class Data {
      public int page {get;set;}
      public int total {get;set;}
      public int records {get;set;}
      public Row[] rows {get;set;}
    }
    
    var myData = new Data(){ .... };
    var json =  new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(myData);
