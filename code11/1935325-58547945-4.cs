    // Following function will parse a keyName and returns the basekey for it.
    // It will also store the subkey name in the out parameter.
    // If the keyName is not valid, we will throw ArgumentException.
    // The return value shouldn't be null. 
    //
    [System.Security.SecurityCritical]  // auto-generated
    private static RegistryKey GetBaseKeyFromKeyName(string keyName, out string subKeyName) {
         if( keyName == null) {
              throw new ArgumentNullException("keyName");
         }
     
         string basekeyName;
         int i = keyName.IndexOf('\\');
         if( i != -1) {
              basekeyName = keyName.Substring(0, i).ToUpper(System.Globalization.CultureInfo.InvariantCulture);
         }
         else {
              basekeyName = keyName.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
         }   
         RegistryKey basekey = null;
     
         switch(basekeyName) {
      case "HKEY_CURRENT_USER": 
          basekey = Registry.CurrentUser;
          break;
      case "HKEY_LOCAL_MACHINE": 
          basekey = Registry.LocalMachine;
          break;
      case "HKEY_CLASSES_ROOT": 
          basekey = Registry.ClassesRoot;
          break;
      case "HKEY_USERS": 
          basekey = Registry.Users;
          break;
      case "HKEY_PERFORMANCE_DATA": 
          basekey = Registry.PerformanceData;
          break;
      case "HKEY_CURRENT_CONFIG": 
          basekey = Registry.CurrentConfig;
          break;
      case "HKEY_DYN_DATA": 
          basekey = RegistryKey.GetBaseKey(RegistryKey.HKEY_DYN_DATA);
          break;      
      default:
          throw new ArgumentException(Environment.GetResourceString("Arg_RegInvalidKeyName", "keyName"));
         }     
         if( i == -1 || i == keyName.Length) {
              subKeyName = string.Empty;
         }
         else {
              subKeyName = keyName.Substring(i + 1, keyName.Length - i - 1);
         }
         return basekey;
     }
