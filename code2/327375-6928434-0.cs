    public sealed class Program
    {
        public static void Main()
        {
            Go("abc", 234);
        }
        [ParamAspect]
        static void Go(string a, int b)
        {
        }
    }
    [Serializable]
    public class ParamAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            object[] argumentContents = args.Arguments.ToArray();
            foreach (var ar in argumentContents)
            {
                Console.WriteLine(ar);
            }
        }
    }
