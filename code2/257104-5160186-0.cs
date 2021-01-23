      loadedAssemblies = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                       where
                         assembly.ManifestModule.Name != "<In Memory Module>"                         
                         && !assembly.FullName.StartsWith("System")
                         && !assembly.FullName.StartsWith("Microsoft")
                         && assembly.Location.IndexOf("App_Web") == -1
                         && assembly.Location.IndexOf("App_global") == -1
                         && assembly.FullName.IndexOf("CppCodeProvider") == -1
                         && assembly.FullName.IndexOf("WebMatrix") == -1
                         && assembly.FullName.IndexOf("SMDiagnostics") == -1
                         && !String.IsNullOrEmpty(assembly.Location)
                       select assembly).ToList();
    
      
