    using (ECR.Impersonator imp = new ECR.Impersonator("XXX", "XXX", "XXX"))
    {
        WindowsIdentity ident = WindowsIdentity.GetCurrent();
        WindowsPrincipal princ = new WindowsPrincipal(ident);
        Console.WriteLine("{0}, {1}", ident.Name, princ.IsInRole(WindowsBuiltInRole.Administrator));
        RegistryKey root = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Connection Strings", RegistryKeyPermissionCheck.ReadWriteSubTree);
        RegistryKey key = root.CreateSubKey("AbacBill", RegistryKeyPermissionCheck.ReadWriteSubTree);
    }
