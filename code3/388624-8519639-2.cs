    DirectoryEntry site = new DirectoryEntry(@"IIS://localhost/w3svc/1/Root");
    PropertyValueCollection values = site.Properties["ScriptMaps"];
    foreach (string val in values)
    {
        if (val.StartsWith(".aspx"))
        {
            string version = val.Substring(val.IndexOf("Framework") + 10, 9);
            MessageBox.Show(String.Format("ASP.Net Version is {0}", version));
        }
    }
