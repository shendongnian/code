    using System.Collections.Generic;
    using System.Linq;
    
    class Foo
    {
        public bool Bar { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            IList<Foo> someList = new List<Foo>() {
                new Foo() { Bar = true },
                new Foo() { Bar = false },
                new Foo() { Bar = true }
            };
    
            var itemsToRemove = someList.Where(f => f.Bar == true).ToArray();
    
            foreach (var foo in itemsToRemove)
            {
                someList.Remove(foo);
            }
        }
    }
