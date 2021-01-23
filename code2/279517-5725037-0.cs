    public class MyFileInfo
    {
        public MyFileInfo(string fname, string somethingElse, string anotherThing);
    }
    public class MyAttribute : System.Attribute
    {
        public MyAttribute(string Name, string Guid, params MyFileInfo[] myFileInfoList)
        {
        }
    }
    [My("Module1", "xxxx",
        new MyFileInfo("a", "b", "c"),
        new MyFileInfo("a", "d", "f"))
    ]
    public class TestClass
    {
    }
