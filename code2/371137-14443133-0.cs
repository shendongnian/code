    using (ServerManager srv = new ServerManager())
    {
        var site = srv.Sites.FirstOrDefault(c => c.Name == siteName);
        var app = site.Applications.Add("/SubDirecory1/SubDirectory2", acbphysicalPath.Text +  @"\SubDirectory1\SubDirectory2");
        app.ApplicationPoolName = txtAppPool.Text;
        srv.CommitChanges();
    }   
