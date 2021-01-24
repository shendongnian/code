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
Next, you can use LINQ to make a flat list (maybe it is not even needed if you will have just one inner List e.g. only Foo1):
    List<MyItem> flatList = Bar.SelectMany(innerList => innerList).ToList();
    string expectedValue = "LineTypeB";
And now to the most important part, you can do it by creating extension method for a list:
    public static class ListExtensionMethods
    {
        public static List<List<MyItem>> SplitListByValue(this List<MyItem> list, string value)
        {
            List<List<MyItem>> splittedList = new List<List<MyItem>>() { new List<MyItem>() }; // initial set
            for (int i = 0; i < list.Count; i++)
            {
                var currentItem = list[i];
                if (i == 0 && currentItem.Value == value) //if the first element already meets the condition, add it to the first sublist and create new one
                {
                    splittedList.LastOrDefault().Add(currentItem);
                    splittedList.Add(new List<MyItem>());
                }
                else if (currentItem.Value == value)
                {
                    splittedList.Add(new List<MyItem>()); //if i-th element meets the condition, create new sublist and add it there
                    splittedList.LastOrDefault().Add(currentItem);
                }
                else
                {
                    splittedList.LastOrDefault().Add(currentItem);
                }
            }
            return splittedList;
        }
    }
      
And then you call it like it follows on your flatList:
    var splitList = flatList.SplitListByValue(expectedValue);
I hope this helps.
