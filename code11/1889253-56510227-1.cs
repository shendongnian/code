IEnumerable<object[]> allRowValues = dataTable.AsEnumerable()
    .SelectMany(dataRow =>
        dataRow.Field<string>(1).Split(',').Select(drug => new[] { dataRow[0], drug, dataRow[2] }));
But what you really want is this:
IEnumerable<Record> allRowValues = dataTable.AsEnumerable()
    .Select(dataRow => new Record(dataRow))
    .SelectMany(record => record.SplitDrugs());
// ...
public class Record
{
    public int Dosage { get; }
    public string Drug { get; }
    public string Patient { get; }
    public Record(int dosage, string drug, string patient)
    {
        Dosage = dosage;
        Drug = drug;
        Patient = patient;
    }
    public Record(DataRow dataRow)
        : this((int)dataRow["Dosage"], (string)dataRow["Drug"], (string)dataRow["Patient"])
    {
    }
    public IEnumerable<Record> SplitDrugs()
    {
        return Drug.Split(',').Select(drug => new Record(Dosage, drug, Patient));
    }
}
Short explanation: with a fancy LINQ you are trying to solve just too many problems of the world liek extracting information from data table, processing rows one by one, applying bussiness logic and merging the result to new data table. That is a good way how to write error-prone, unreadable, untestable, unstable and unmaintanable code.
Incomplete list of people who will eventually thank you for chosing the second option:
 - **your future self**
 - your teammates
 - your code reviewer
 - unit test writer
 - end users
 - your teacher (if assignment)
 - SO community
While I'm at it I'll save you some time debugging your transformation of `allRowValues` (which in your case is of type `IEnumerable<string[]>`) back to `DataTable`. If you think it will contain 3 columns, then you're wrong. Instead, it will contain columns like `Length`, `LongLength`, `Rank`, ... Have a look at [properties Array class][1] to figure out why.
Edit
----
OP has refined the original intent in a comment under another answer.
> ... , but i just posted a prototype of datatable,infact actually 180 columns are there.DO i need to add all 180 columns manually in newRow.ItemArray, when there is a split of comma seperated values???Any easier way?
Yes, there is an easier way. Involving generics you can expand the usage beyond this limited use case:
// extension method
public static DataTable ExpandColumn<T>(this DataTable dataTable, string columnName,
    Func<T, IEnumerable<T>> expandField)
{
    var clonedDataTable = dataTable.Clone();
    var columnIndex = dataTable.Columns.IndexOf(columnName);
    var column = dataTable.Columns[columnIndex];
    foreach (var dataRow in dataTable.AsEnumerable())
    {
        var valueToExpand = dataRow.Field<T>(column);
        var expandedValues = expandField(valueToExpand);
        var originalValues = dataRow.ItemArray;
        foreach (var value in expandedValues)
        {
            originalValues[columnIndex] = value;
            clonedDataTable.Rows.Add(originalValues);
        }
    }
    return clonedDataTable;
}
// usage
var dataTableNew = dataTable.ExpandColumn<string>("Drug", drug => drug.Split(','));
The above extension method clones `DataTable` instance by copying original rows and expands values in specified column by applying `expandField` function for each value.
I'd still like you to learn lesson from what I wrove above the edit and think twice about your design.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netframework-4.8#properties
