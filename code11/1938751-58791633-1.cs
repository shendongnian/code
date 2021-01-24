    if (!assemblyName.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase) && !assemblyName.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase))
            {
                string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
                if (assemblyPath != null)
                {
                    return this.LoadFromFile(assemblyPath);
                }
            }
