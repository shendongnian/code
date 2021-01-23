    public class FqnResolver
    {
        public FqnResolver(IEnumerable<Assembly> assemblies)
        {
            Assemblies = new List<Assembly>(assemblies);
        }
        public FqnResolver(params Assembly[] assemblies) : this(assemblies as IEnumerable<Assembly>) { }
        public FqnResolver() : this(new Assembly[0]) { }
        public ICollection<Assembly> Assemblies { get; private set; }
        public string GetFqn(string name)
        {
            var candidates = from a in assemblies
                             from t in a.GetTypes()
                             where t.Name == name
                             select t.FullName;
            return candidates.First(); // will throw if no valid type was found
                                       // and does not count duplicates
        }
    }
