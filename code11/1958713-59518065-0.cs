C#
public IList<ForeignTableViewModl> QueryForeignTable(string tableName)
{
	using(var db = new Db())
	{
		var sql = @"
select
    fk.name as [FkName],
    tp.name as [ParentTable],
    tr.name as [RefrencedTable]
from sys.foreign_keys fk
inner join sys.tables tp on fk.parent_object_id = tp.object_id
inner join sys.tables tr on fk.referenced_object_id = tr.object_id
where tp.name = @p0
	";
		return db.Database.SqlQuery<ForeignTableViewModl>(sql, tableName).ToList();
	}
}
public class ForeignTableViewModl
{
	public string FkName { get; set; }	
	public string ParentTable { get; set; }	
	public string RefrencedTable { get; set; }	
}
and it'll get result of northwind demo db like : 
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/mYSTN.png
