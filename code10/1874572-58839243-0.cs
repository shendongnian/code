C#
public class MyEntity
{
    public int Id { get; set; }
    public int MyInt { get; set; }
}
You will get the exception: `System.Data.SqlTypes.SqlNullValueException: 'Data is Null. This method or property cannot be called on Null values.'`
To fix this, just change the type of your `MyInt` property to `Nullable<int>` or `int?`:
C#
public class MyEntity
{
    public int Id { get; set; }
    public int? MyInt { get; set; }
}
Note: This is not an answer to the original question, but is an answer to the question in the title.
