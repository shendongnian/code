    public class MyClass
    {
        public void DoSomethingInOneLine()
        {
            // do something
        }
    }
    public static void Test(System.Collections.Generic.IEnumerable<MyClass> list)
    {
        list.ForEach(item => item.DoSomethingInOneLine());
    }
