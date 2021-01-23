    [assembly: Foo("Bar", typeof(Bar))]
    [assembly: Foo("Baz", "MyNamespace.Bar+Baz, MyAssembly")]
    public class Bar
    {
        private class Baz
        {
        }
    }
