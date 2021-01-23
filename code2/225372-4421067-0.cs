    Type analyserType = typeof(IMFDBAnalyserPlugin);
    foreach(Type t in assembly.GetTypes()) {
        if(t.IsSubtypeOf(analyserType) {
            plugins.Add((IMFDBAnalyserPlugin) Activator.CreateInstance(t));
        }
    }
