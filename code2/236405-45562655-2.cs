using System;
namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var fo = new Fo();
            fo.Init();
            Console.WriteLine(fo.SomeBar.SomeValue);
            fo.SomeBar.SomeValue = "Changed it!";
            Console.WriteLine(fo.SomeBar.SomeValue);
            Console.Read();
        }
        public class Fo
        {
            public Bar SomeBar { get; private set; }
            public void Init()
            {
                SomeBar = new Bar{SomeValue = "Hello World!"};
            }
        }
        public class Bar
        {
            public String SomeValue { get; set; }
        }
    }
}
</pre>
