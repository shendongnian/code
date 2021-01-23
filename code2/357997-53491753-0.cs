        Private Function JSE_ReadRegistry() As RegistryKey
            ' Read the SubKey names from the registry
            Dim rkKey As RegistryKey = Nothing
            If Environment.Is64BitOperatingSystem Then
                rkKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            Else
                rkKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
            End If
            rkKey.Close()
            Return rkKey
        End Function
