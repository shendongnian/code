    public class Foo
    {
        public Foo(string name, DateTime dt1, DateTime dt2)
        {
            Name = name;
            DT1 = dt1;
            DT2 = dt2;
        }
    
        public string Name { get; set; }
        public DateTime DT1 { get; set; }
        public DateTime DT2 { get; set; }
    }
    
    public class Example
    {
        public List<Foo> example(DataView dataViewer)
        {
            var foos = new List<Foo>();        
    
            foreach(var data in dataViewer)
            {
                foos.Add(new Foo(data.Name, data.DT1, data.DT2);
            }
    
            return foos;
        }
    }
