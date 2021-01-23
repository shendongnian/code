    public class EntityAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().Contains(typeof (IPersistable));
        }
    }
