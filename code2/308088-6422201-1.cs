    protected override void OnInit(EventArgs e)
    {
        if (!this.IsPostback) // write links
        {
            foreach (var di in new DirectoryInfo(path).EnumerateDirectories())
            {
                var link = new HyperLink()
                {
                    Text = di.Name,
                    NavigateUrl = String.Format("?dir={0}", HttpUtility.UrlEncode(di.Name)
                };
                this.Controls.Add(link);
            }
        }
        else // process link click
        {
            string path = HttpUtility.UrlDeconde(this.Request["dir"]); // check for null, etc
            new DirectoryInfo(path).Delete();
        }
    }
