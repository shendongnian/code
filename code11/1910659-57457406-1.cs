    try
    {
        RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\x86 ");
        if(rk == null)
        {
          MessageBox.Show("Something doesn't exists");
        }
    }
    catch(Exception ex)
    {
         // your exception handling process
    }
