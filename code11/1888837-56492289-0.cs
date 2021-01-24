public class MyClass
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
}
Then the LINQ which u can use is something like this:
var newList = List.GroupBy(l => l.Text).Select(g => new MyClass { Text = g.Key, Date = g.Max(i => i.Date)}).ToList();
This will give you a filtered list as per your requirement.
