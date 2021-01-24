csharp
public class TableParameter
{
    public string Table { get; set; }
    public string ParameterID { get; set; }
    public string Value { get; set; }
}
[Given(@"the following parameter is changed")]
public void GivenTheFollowingParameterIsChanged(Table table)
{
    var data = table.CreateSet<TableParameter>();
    foreach (var row in data)
    {
        switch (row.Table)
        {
            case "table1":
                // Do stuff with row.ParameterID and row.Value to call the service
                break;
            case "table2":
                // Do stuff with row.ParameterID and row.Value to call the service
                break;
            default:
                throw new NotSupportedException("Unsupported table name: " + row.Table);
        }
    }
}
As far as I know there is no way to create different object instances based on the table row, since all the SpecFlow table helpers return a single object or a collection of objects of the same type. Even if you could create different instances per row, you are still forced to cast each row to their proper sub class.
It will be easier to create the proper abstraction, and then use an `if` or `switch` statement to further customize the behavior.
