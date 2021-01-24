    proc.ErrorDataReceived += (sender, e) =>
    {
        UnityEngine.Debug.LogError(e.Data);
    };
    proc.OutputDataReceived += (sender, e) =>
    {
        UnityEngine.Debug.Log(e.Data);
    };
    proc.Exited += (sender, e) =>
    {
        UnityEngine.Debug.Log(e.ToString());
    };
    
    proc.Start();
