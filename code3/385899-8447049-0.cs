    abstract class MyBaseClass
    {
        public Dictionary<int,string> dic { get; set; }
        public MyBaseClass()
        {
            dic = new Dictionary<int, string>(5);
        }
        public void Add(int key, string value)
        {
            dic.Add(key, value);
        }
    }
    public class MyClass1 : MyBaseClass
    {
        public MyClass1():base()
        {          
        }        
    }
    public class MyClass2 : MyBaseClass
    {
        public MyClass2():base()
        {
        }
        public void Save()
        {
            Add(1, "somevalue");
        }
    }
