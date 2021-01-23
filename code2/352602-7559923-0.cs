    public class View
    {
        public string Text { get; set; }
        public string AnotherText { get; set; }
        public int SomeInt { get; set; }
        public List<DataItem> DataItems { get; set; }
    }
    public class DataItem
    {
        public Person person { get; set; }
    }
    public class Person
    {
        public int Age {get;set;}
    }
