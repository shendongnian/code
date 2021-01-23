        Private Sub ResetConfigMechanism()
            GetType(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, 0)
            GetType(ConfigurationManager).GetField("s_configSystem", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, Nothing)
            GetType(ConfigurationManager).Assembly.GetTypes().Where(Function(x) x.FullName = "System.Configuration.ClientConfigPaths").First().GetField("s_current", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, Nothing)
        End Sub
