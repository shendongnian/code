        if (obj == null) 
        {
            //// you enter here only if obj is null
            //Download and Satisfy
            DeploymentCatalog DC = new DeploymentCatalog("TheXAPfile.xap");
            DC.DownloadCompleted += (s, e) =>
            {
                catalog.Catalogs.Add(f); //catalog is AggregateCatalog
                //// here you are assuming that obj is not null anymore. Why???
                obj.Show();
            };
            DC.DownloadAsync();
        }
 
