    public class CustomLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public CustomLinqToHqlGeneratorsRegistry()
            : base()
        {
            MethodInfo toStringMethod = ReflectionHelper.GetMethodDefinition<int>(x => x.ToString());
            RegisterGenerator(toStringMethod, new ToStringGenerator());
        }
    }
