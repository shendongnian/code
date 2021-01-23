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
            private Bar _someHiddenBar;
            public Bar SomeBar => new Bar(_someHiddenBar);
            public void Init()
            {
                _someHiddenBar = new Bar{SomeValue = "Hello World!"};
            }
        }
        public class Bar
        {
            public String SomeValue { get; set; }
            public Bar(){}
            public Bar(Bar previousBar)
            {
                SomeValue = previousBar.SomeValue;
            }
        }
    }
}
</pre>
