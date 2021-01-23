    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var baseAssemblies = base.GetAssemblies();
            var assemblies = new List<Assembly>(baseAssemblies);
            assemblies.Add(Assembly.GetAssembly(typeof(MyAssembliesResolver)));
            return new List<Assembly>(assemblies);
        }
    }
