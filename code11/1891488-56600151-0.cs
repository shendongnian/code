    using (RegistryKey rkLocalMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
        using (RegistryKey rk = rkLocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Terminal Server Client", true))
        {
            rk.SetValue("RemoteDesktop_SuppressWhenMinimized", 2, RegistryValueKind.DWord);
        }
    }
