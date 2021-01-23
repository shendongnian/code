    public interface IPersonFactory
    {
        IPerson GetPersonInstance(string name);
    }
    
    public class StructureMapPersonFactory : IPersonFactory
    {
        public IPerson GetPersonInstance(string name)
        {
            return ObjectFactory.GetNamedInstance<IPerson>(name);
        }
    }
