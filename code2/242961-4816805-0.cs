    using System;
    using System.ComponentModel;
    using System.Linq;
    [Category("nice")]
    class Foo {  }
    static class Program
    {
        static void Main()
        {
            var ca = TypeDescriptor.GetAttributes(typeof(Foo))
                  .OfType<CategoryAttribute>().FirstOrDefault();
            Console.WriteLine(ca.Category); // <=== nice
            TypeDescriptor.AddAttributes(typeof(Foo),new CategoryAttribute("naughty"));
            ca = TypeDescriptor.GetAttributes(typeof(Foo))
                  .OfType<CategoryAttribute>().FirstOrDefault();
            Console.WriteLine(ca.Category); // <=== naughty
        }
    }
