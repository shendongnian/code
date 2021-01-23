    [assembly: Foo("Bar", typeof(Bar))]
    [assembly: Foo("Baz", "Foo.Bar+Baz, MyAssembly")]
    namespace Foo
    {
        public class Bar
        {
            private class Baz
            {
            }
        }
    }
