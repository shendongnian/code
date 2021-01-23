      [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, "{Your application folder name}");
                Directory.Delete(path, true);
            }
            catch(Exception)
            {
            }
            base.Uninstall(savedState);
        }
