    Using Microsoft.Win32;
...
    RegistryKey AeroPeek = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true);
           if ((int)AeroPeek.GetValue("EnableAeroPeek") == 1)
            {
                MessageBox.Show("Aero Peek is ON");
            }
            else MessageBox.Show("Aero Peek is OFF");
