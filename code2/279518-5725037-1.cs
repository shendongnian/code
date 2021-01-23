    public class MyFileInfo
    {
        public MyFileInfo(string fname, string somethingElse, string anotherThing);
    }
    public class ModuleAttribute : System.Attribute
    {
        public ModuleAttribute(string Name, string Guid, params MyFileInfo[] myFileInfoList)
        {
        }
    }
    [Module("Module1", "xxxx",
        new MyFileInfo("a", "b", "c"),
        new MyFileInfo("a", "d", "f"))
    ]
    public class TestClass
    {
    }
