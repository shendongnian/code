    public class MyClass
    {
        public MyClass()
        {
    #if DEBUG // Only run in debug mode, because of performance.
            StackTrace trace = new StackTrace();
            var callingMethod = trace.GetFrames()[1].GetMethod();
            if (callingMethod.IsStatic && 
                callingMethod.Name == ".cctor")
            {
                throw new InvalidOperationException(
                    "You naughty boy!");
            }
    #endif
        }
    }
