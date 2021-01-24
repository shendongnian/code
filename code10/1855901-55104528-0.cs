    protected void Page_PreRender(object sender, EventArgs e)
    {
        var checkMe1 = _blobStorageService.getCloudBlobContainer();
        var checkMe2 = checkMe1.GetDirectoryReference("ppp");
        var cehckMe3 = checkMe2.ListBlobs();
        var checkMe4 = from o in cehckMe3
                        select new { Url = o.Uri }.ToList();
        fileDisplayControl.DataSource = checkMe4;
        // List view to bind to its data source
        fileDisplayControl.DataBind();
    }
