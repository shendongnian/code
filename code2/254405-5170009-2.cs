    protected void Page_Load(object sender, EventArgs e)
    {
        RegistryKey root = null;
        using (ECR.Impersonator imp = new ECR.Impersonator("XXX", "XXX", "XXX"))
        {
            WindowsIdentity ident = WindowsIdentity.GetCurrent();
            WindowsPrincipal princ = new WindowsPrincipal(ident);
            lit.Text = string.Format("{0}, {1}", ident.Name, princ.IsInRole(WindowsBuiltInRole.Administrator));
            root = Registry.LocalMachine.CreateSubKey("SOFTWARE\\XXX", RegistryKeyPermissionCheck.ReadWriteSubTree);
        }
        root.SetValue("test", "test");
        RegistryKey key = root.CreateSubKey("XXX", RegistryKeyPermissionCheck.ReadWriteSubTree);
    }
