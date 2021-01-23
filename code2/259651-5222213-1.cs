    public class MyClass
    {
        public MyClass()
        {
            StackTrace trace = new StackTrace();
            var callingMethod = trace.GetFrames()[1].GetMethod();
            if (callingMethod.IsStatic && 
                callingMethod.Name == ".cctor")
            {
                throw new InvalidOperationException(
                    "You naughty boy!");
            }
        }
    }
