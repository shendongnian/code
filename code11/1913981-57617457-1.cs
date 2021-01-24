csharp
public class MyClass
{
    public DateTime datetime_field; // note this needs to be public, not private
}
public void MyMethod(DateTime date)
{
    List<MyClass> myData = new List<MyClass>()
    {
        // initialization
    };
    var query = myData.Where(obj => obj.date_time == date).ToList();
    myDataGridView.DataSource = query;
}
// usage
string value = DateTime.Now.ToString();
if (DateTime.TryParse(value, out DateTime dt))
{
    MyMethod(dt);
}
