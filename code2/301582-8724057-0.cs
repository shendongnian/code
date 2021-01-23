    public class CustomLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public CustomLinqToHqlGeneratorsRegistry()
            : base()
        {
            MethodBase toStringMethod = typeof(int)
                    .GetMethods(
                         BindingFlags.Public |
                         BindingFlags.Instance
                       )
                    .Where(o => o.Name == "ToString").First();
            RegisterGenerator((MethodInfo)toStringMethod, new ToStringGenerator());
        }
    }
