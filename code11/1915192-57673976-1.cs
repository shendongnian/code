CREATE TABLE TestTable
(
	[ID]			[INT] IDENTITY (1,1) NOT NULL CONSTRAINT TestTable_P_KEY PRIMARY KEY,
	[Name]			[VARCHAR] (100) NOT NULL,
	[ComputedCol]	[VARCHAR] (100) NOT NULL DEFAULT '',
	[NonWriteCol]	[VARCHAR] (100) NOT NULL DEFAULT ''
)
[Table("TestTable")]
public class MyTable
{
	[Key]
	public int ID { get; set; }
	public string Name { get; set; }
	[Computed]
	public string ComputedCol { get; set; }
	[Write(false)]
	public string NonWriteCol { get; set; }
}
int id;
using(SqlConnection conn = new SqlConnection(@"connection string"))
{
	MyTable myTable = new MyTable();
	myTable.Name = "Name";
	myTable.ComputedCol = "computed";
	myTable.NonWriteCol = "writable";
	conn.Insert<MyTable>(myTable);
	id = myTable.ID;
}
using(SqlConnection conn = new SqlConnection(@"connection string"))
{
	MyTable myTable = conn.Get<MyTable>(id);
	myTable.Name = "Name_1";
	myTable.ComputedCol = "computed_1";
	myTable.NonWriteCol = "writable_1";
	conn.Update<MyTable>(myTable);
}
With above code, you will observe that no matter which attribute you choose to decorate the property, it will neither be considered for `INSERT` nor for `UPDATE`. So basically, both the attributes are playing same role.
This can be further confirmed in [Dapper.Tests.Contrib](https://github.com/StackExchange/Dapper/tree/07bc83f2b780da79ea4b780fa27baa9cf87c608d/Dapper.Tests.Contrib) test project on github.
