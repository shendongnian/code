    // readonly (instead of const) allows to get value at runtime
    public static readonly string dll =       Environment
      .GetEnvironmentVariable("DLLProj_HOME", EnvironmentVariableTarget.Machine)
      .ToString();
    // Relative Path
    //TODO: put the right dll name here 
    [DllImport("DLLProjCore2.dll", EntryPoint = "met1_method1")]
    private static extern void Core_met1_method1(string prefix, string version);
    public static void met1_method1(string prefix, string version) {
      string savedPath = Environment.CurrentDirectory;
      try {
        // We set current directory
        Environment.CurrentDirectory = Path.GetDirectoryName(dll);
        // And so we can load library by its relative path 
        met1_method1(prefix, version);
      }
      finally {
        Environment.CurrentDirectory = savedPath;
      }
    }
