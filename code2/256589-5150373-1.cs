    public static class Test
    {
        public static bool IsActionDelegate(this Type source)
        {
            var type = source.Name;
            return source.Name.StartsWith("Action");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> one = s => { return; };
            Action<int, string> two = (i, s) => { return; };
            Func<int, string> function = (i) => { return null; };
            var single = one.GetType().IsActionDelegate();
            var dueces = two.GetType().IsActionDelegate();
            var func = function.GetType().IsActionDelegate();
        }
    }
