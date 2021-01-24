System.Data.DataTable table = new DataTable("Table");
column.DataType = System.Type.GetType("System.String");
table.Columns.Add(column);
Using this strategy, you do not need to format the received decimal item.
**If you are restricted to use a concrete data table**
Even if you are restricted to use a concrete data table, you shouldn't have any problem. 
The only thing you need to do is to format the received data inside the user interface.
I hope this answer is useful.   
     
