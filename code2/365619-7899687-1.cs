    public static void GetConfigurationElement(XElement Configuration, string parameter, out bool LaunchDebugger)
            {
                var value = Configuration.Element(parameter).Value;
                LaunchDebugger = false;
                if (value != null)
                    LaunchDebugger = Convert.ToBoolean(value);
            }
