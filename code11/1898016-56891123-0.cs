public class MyItem
{
    public string Key { get; set; }
    public string Value { get; set; }
    public MyItem(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
And you have initial lists created like this:
    List<MyItem> Foo1 = new List<MyItem>();
    Foo1.Add(new MyItem("Test1", "LineTypeA"));
    Foo1.Add(new MyItem("Test2", "LineTypeA"));
    Foo1.Add(new MyItem("Test3", "LineTypeB"));
    Foo1.Add(new MyItem("Test4", "LineTypeA"));
    Foo1.Add(new MyItem("Test5", "LineTypeB"));
    
    List<MyItem> Foo2 = new List<MyItem>();
    Foo2.Add(new MyItem("Test1", "LineTypeA"));
    Foo2.Add(new MyItem("Test2", "LineTypeA"));
    Foo2.Add(new MyItem("Test3", "LineTypeB"));
    Foo2.Add(new MyItem("Test4", "LineTypeA"));
    Foo2.Add(new MyItem("Test5", "LineTypeB"));
    
    List<MyItem> Foo3 = new List<MyItem>();
    Foo3.Add(new MyItem("Test1", "LineTypeA"));
    Foo3.Add(new MyItem("Test2", "LineTypeA"));
    Foo3.Add(new MyItem("Test3", "LineTypeB"));
    Foo3.Add(new MyItem("Test4", "LineTypeA"));
    Foo3.Add(new MyItem("Test5", "LineTypeB"));
    
    
    List<List<MyItem>> Bar = new List<List<MyItem>> ();
    Bar.Add(Foo1);
    Bar.Add(Foo2);
    Bar.Add(Foo3);
And now the most important part(if I got your question correctly), you can use LINQ to Select smaller lists based on filtering with Where for all items which have e.g. "LineTypeB" as Value:
    var splittedList = Bar.Select(innerList => innerList.Where(item => item.Value.Equals("LineTypeB")));
I hope this helps, still I am not sure if I got it correctly.
