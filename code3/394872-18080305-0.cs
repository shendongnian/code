	using System;
	using System.Collections.Generic;
	using Mono.Cecil;
    public class MyAssemblyResolver : BaseAssemblyResolver
    {
        private readonly IDictionary<string, AssemblyDefinition> cache;
        public MyAssemblyResolver()
        {
            this.cache = new Dictionary<string, AssemblyDefinition>(StringComparer.Ordinal);
        }
        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            AssemblyDefinition assemblyDefinition = null;
            if (this.cache.TryGetValue(name.FullName, out assemblyDefinition))
                return assemblyDefinition;
            try  //< -------- My addition to the code.
            {
                assemblyDefinition = base.Resolve(name);
                this.cache[name.FullName] = assemblyDefinition;
            }
            catch { } //< -------- My addition to the code.
            return assemblyDefinition;
        }
        protected void RegisterAssembly(AssemblyDefinition assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            string fullName = assembly.Name.FullName;
            if (this.cache.ContainsKey(fullName))
                return;
            this.cache[fullName] = assembly;
        }
    }
