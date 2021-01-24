csharp
public class MyClass
{
    public DateTime datetime_field; // note this needs to be public, not private
}
public void MyMethod(Expression<Func<MyClass, bool>> clause)
{
    List<MyClass> myData = new List<MyClass>()
    {
        // initialization
    };
    var query = myData.Where(clause).ToList();
    myDataGridView.DataSource = query;
}
// usage
string value = DateTime.Now.ToString();
if (DateTime.TryParse(value, out DateTime dt))
{
    MyMethod(obj => obj.datetime_field == dt);
}
