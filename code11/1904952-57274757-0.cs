CREATE TABLE [mytable]
(
	[mytableuuid]		[UNIQUEIDENTIFIER] NOT NULL,
	[clientuuid]		[UNIQUEIDENTIFIER] NOT NULL
)
Following is the model declaration:
[Table("mytable")]
public class MyTable : BaseDataObject<MyTable>
{
	[Key]
	[Column("mytableuuid")]
	public Guid MyTableUUID { get; set; }
	[Column("clientuuid")]
	public Guid ClientUUID { get; set; }
}
public abstract class BaseDataObject<TDOType> where TDOType : class
{
	public static TDOType Get(Guid lObjectUUID, SqlConnection conn)
	{
		return conn.Get<TDOType>(lObjectUUID);
	}
	public Guid Insert(SqlConnection conn)
	{
		try
		{
			return conn.Insert<Guid, TDOType>(this as TDOType);//<--Just change this call
		}
		catch(Exception ex)
		{
			throw;
		}
	}
}
Following is how I call the `Insert` method:
using(SqlConnection conn = new SqlConnection(@"connectionstring"))
{
	MyTable myTable = new MyTable();
	myTable.MyTableUUID = Guid.NewGuid();
	myTable.ClientUUID = Guid.NewGuid();
	myTable.Insert(conn); 
}
