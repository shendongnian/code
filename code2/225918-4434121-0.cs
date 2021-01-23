    public class MyConfiguration : DefaultAutomappingConfiguration {
        public override bool ShouldMap(Type type) {
            return type.Namespace == typeof(Hello).Namespace;
        }
    }
