 c#
public class IntIdTableType
{
    public int Id { get; set; }
}
Then with your connection you can do something like:
 c#
connection.QueryAsync<myViewModel>("[dbo].[spName]", param: new
    {
        ((List<IntIdTableType>)model.YourIListPropertyModel).ToDataTable(),
    }, commandType: CommandType.StoredProcedure);
Then in your SQL create table type 
 SQL
CREATE TYPE intHelper AS TABLE
( 
    Id INT
)
And finally in your stored procedure in your params:
    @MyIdTableType [intHelper] READONLY
Query:
 sql
    DELETE FROM dbo.HouseInfo WHERE ParentHouseId IS NULL OR ParentOwnerId IS NULL AND SomeColumn IN (@MyIdTableType)
