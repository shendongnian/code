        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] 
           {
               Assembly.GetExecutingAssembly()
              // Ensure your external assembly is included.
           };
        }
