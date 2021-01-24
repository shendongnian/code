sql
CREATE TYPE DataIds AS TABLE  
(  
    DataID int 
) 
In your method, create a new `DataTable` from your list
c#
using System.Ling;
using System.Data;
// ...
var dataIds = new DataTable();  
dataIds.Columns.Add("DataID", typeof(int));
List<string> dataList = new List<string>();
// do what ever to fill your list with parameters
foreach (String item in dataList)
{
    DataRow row = dataIds.NewRow();
    row["DataID"] = item;
    table.Rows.Add(row);
}
// When fetching data
var mySQLQueryString = "...WHERE DataID IN (SELECT DataID FROM @mySQLVariable)";
SqlParameter param = new SqlParameter("@mySQLVariable", SqlDbType.Structured);  
param.Value = dataIds;  
param.TypeName = "dbo.DataIds";  
return context.Database.SqlQuery<ConcretePOCO>(mySQLQueryString, param).ToList();
