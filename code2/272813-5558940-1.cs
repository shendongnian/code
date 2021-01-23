    public abstract class BaseAbstract
    {
        public void PrintMethodNames()
        {
            BindingFlags flags =
                BindingFlags.DeclaredOnly |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static;
    
            foreach (MethodInfo mi in GetType().GetMethods(flags))
            {
                Console.WriteLine(mi.Name);
            }
        }
    }
