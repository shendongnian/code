    internal class Program
    {
        private static void Main(string[] args)
        {
            Wrapper wrap = new Wrapper
            {
                SOmeProperty = new SomeClass
                {
                    Number = 007
                }
            };
            Type type = wrap.GetType();
            PropertyInfo info = type.GetProperty("SOmeProperty", BindingFlags.NonPublic | BindingFlags.Instance);
            SomeClass value = (SomeClass)info.GetValue(wrap, null);
            // use `value` variable here
        }
    }
