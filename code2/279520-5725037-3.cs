    public class MyFileInfo
    {
        string fname;
        string anotherThing;
        string somethingElse;
        public MyFileInfo(string serializedFileInfo)
        {
            string[] parts = serializedFileInfo.Split(',');
            fname = parts[0];
            anotherThing = parts[1];
            somethingElse = parts[2];
        }
        public static implicit operator MyFileInfo(string things)
        {
            return new MyFileInfo(things);
        }
    }
    public class ModuleAttribute : System.Attribute
    {
        List<MyFileInfo> fiList;
        public ModuleAttribute(string Name, string Guid, params string[] serializedFileInfoList)
        {
            fiList = serializedFileInfoList.Select(s => new MyFileInfo(s)).ToList();
        }
    }
    [Module("Module1", "xxxx",
        "a,b,c",
        "d,e,f"
        )
    ]
    public class TestClass
    {
    }
