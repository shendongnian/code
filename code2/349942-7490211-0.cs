    public interface INamed
    {
        string Name { get; set; }
    }
    
    public class Foo<T>
        : List<T>
        where T : INamed
    {
        public bool IsUnique(T item)
        {
            T result = Find(x => x.Name == item.Name);
            if (result == null || result.Equals(default(T)))
                return true;
            return false;
        }
    }
    
    public class BarClass : INamed
    {
        public string Name { get; set; }
    }
    public struct BarStruct : INamed
    {
        public string Name { get; set; }
    }
    [STAThread]
    static void Main()
    {
        BarClass bc = new BarClass { Name = "test" };
        Foo<BarClass> fc = new Foo<BarClass>();
        fc.IsUnique(bc);
    
        BarStruct bs = new BarStruct { Name = "test" };
        Foo<BarStruct> fs = new Foo<BarStruct>();
        fs.IsUnique(bs);
    }
