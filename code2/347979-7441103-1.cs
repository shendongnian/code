    public class MyClass
    {
        public int Num = (new Random()).Next(100);
    }
    var manyA = new List<MyClass>();
    var groupedByHash = manyA.ToLookup(p => p.GetHashCode());
