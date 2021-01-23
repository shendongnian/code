    AssemblyName name = new AssemblyName( args.Name );
    foreach( Assembly pluginAssembly in LoadedPluginAssemblies ) {
      if( AssemblyName.ReferenceMatchesDefinition( name, pluginAssembly.GetName() ) ) 
        return pluginAssembly;
    }
