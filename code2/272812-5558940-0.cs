    public abstract class BaseAbstract
    {
        public void PrintMethodNames()
        {
            BindingFlags flags =
                BindingFlags.DeclaredOnly |
                BindingFlags.Public |
                BindingFlags.Instance;
    
            foreach (MethodInfo mi in GetType().GetMethods(flags))
            {
                Console.WriteLine(mi.Name);
            }
        }
    }
