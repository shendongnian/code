    var populator = new JsonPopulator();
    var obj = new MyClass();
    populator.PopulateObject(obj, "{\"Title\":\"Startpage\",\"Link\":\"/index\"}");
    populator.PopulateObject(obj, "{\"Head\":\"Latest news\",\"Link\":\"/news\"}");
    public class MyClass
    {
        public string Title { get; set; }
        public string Head { get; set; }
        public string Link { get; set; }
    }
