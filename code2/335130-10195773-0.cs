    const string pathKeyName = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
    var pathKey = Registry.LocalMachine.OpenSubKey(pathKeyName);
    var path = (string)pathKey.GetValue("PATH", "", RegistryValueOptions.DoNotExpandEnvironmentNames);
    // Manipulate path here, storing in path
    Registry.SetValue(String.Concat(@"HKEY_LOCAL_MACHINE\", pathKeyName), "PATH", path);
