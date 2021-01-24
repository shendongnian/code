csharp
public class MyClass
{
    public DateTime datetime_field; // note this needs to be public, not private
}
public void MyMethod(string strDate)
{
    if (DateTime.TryParse(value, out DateTime dt))
    {
        List<MyClass> myData = new List<MyClass>()
        {
            // initialization
        };
   
        var roundedDate = new DateTime(dt.Year, dt.Month, dt.Day,
                                       dt.Hour, dt.Minute, dt.Second);
        var query = myData.Where(obj => obj.date_time == roundedDate).ToList();
        myDataGridView.DataSource = query;   
    }
}
// usage
string value = DateTime.Now.ToString();
MyMethod(value);
