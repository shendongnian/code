    public class test
    {
        public int id { get; set; } = 0;
        public string desc { get; set; } = "";
        public test(string s, int i)
        {
            desc = s;id = i;
        }
    }
    private void Main()
    {
        var oldRecords = new List<test>()
        {
            new test("test",1),
            new test("test",2)
        };
        var newRecords = new List<test>()
        {
            new test("test1",1),
            new test("test",2)
        };
        SomeMethod(oldRecords, newRecords, new List<string>() { "id", "desc" });
    }
