    DataTable table=new DataTable("MyTable");//Actually I am getting this table data from database
    
    DataColumn col=new DataColumn("Createdby");
    
    var  childrows =  table.AsEnumerable().Select( row => row.Field<object>(col)).Distinct().ToArray();
 
