            protected void btnExcelExport_Click(object sender, EventArgs e)
            {
                //long running process here, taking advantage of the update progress panel
                var bytes = GetExcelFile();
                //generate a key to pass to the download page to access the file bytes
                var cacheKey = Guid.NewGuid().ToString("N");//N means no hyphens
                //placing the result in cache for a few seconds so the download page can grab it             
                Context.Cache.Insert(key: cacheKey, value: bytes, dependencies: null, absoluteExpiration: DateTime.Now.AddSeconds(30), slidingExpiration: System.Web.Caching.Cache.NoSlidingExpiration);
                ifmExcel.Attributes.Add("src", String.Format("MyDownloadPage.aspx?cacheKey={0}", cacheKey));
            }
