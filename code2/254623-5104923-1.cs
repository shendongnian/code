    public static bool SetUnsafeHeaderParsing()
        {
            Assembly oAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (oAssembly != null)
            {
                Type oAssemblyType = oAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (oAssemblyType != null)
                {
                    
                    object oInstance = oAssemblyType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (oInstance != null)
                    {
                        FieldInfo objFeild = oAssemblyType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (objFeild != null)
                        {
                            objFeild.SetValue(oInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
