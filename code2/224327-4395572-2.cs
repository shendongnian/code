    string assemblyName = "PrimaryKeyChecker.dll";
    Assembly assembly = Assembly.LoadFrom(assemblyName);
    Type local_type = assembly.GetType("PrimaryKeyChecker.PrimaryKeyChecker");
    IMFDBAnalyserPlugin analyser =
       (IMFDBAnalyserPlugin)Activator.CreateInstance(local_type);
    DataTable response = analyser.RunAnalysis(objConnectionString.ConnectionString);
