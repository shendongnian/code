    public class ClassWithMethod
    {
        [ExecuteMe("hello", "reflection")]
        public void M3(params object[] args)
        {
            var strings = args.Where(arg => arg != null).Select(arg => arg.ToString());
            Console.WriteLine(string.Join(", ", strings));
        }
        // Just to verify that we're only invoking methods with the attribute.
        public void MethodWithoutAttribute() { }
    }
