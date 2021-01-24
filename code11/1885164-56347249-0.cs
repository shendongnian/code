    public static bool CheckJavaIsInstalled(TaskLoggingHelper log) {
      if (CheckJavaIsInstalled(log, false) || CheckJavaIsInstalled(log, true))
        return true;
...
    private static bool CheckJavaIsInstalled(TaskLoggingHelper log, bool is64) {
      try {
        using (var rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, is64 ? RegistryView.Registry64 : RegistryView.Registry32)) {
          using (var subKey = rk.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment")) {
            if (subKey == null)
              return false;
            string currentVerion = subKey.GetValue("CurrentVersion").ToString();
            float version;
            if (float.TryParse(currentVerion, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out version)) {
              if (version < 1.8f)
                log.LogMessage(MessageImportance.High, "Java version {0} older than 1.8", version);
            }
            else
              log.LogMessage(MessageImportance.High, "Failed parse Java version {0} ", currentVerion);
          }
        }
      }
      catch (Exception ex) {
        log.LogError("Java check failed");
        log.LogErrorFromException(ex);
        return false;
      }
      return true;
    }
