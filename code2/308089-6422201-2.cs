    protected override void OnInit(EventArgs e)
    {
        string dir = this.Request["dir"];
        if (String.IsNullOrEmpty(dir)) // write links
        {
            string path = @"d:\temp";
            foreach (var di in new DirectoryInfo(path).EnumerateDirectories())
            {
                var link = new HyperLink()
                {
                    Text = di.Name,
                    NavigateUrl = String.Format("?dir={0}", HttpUtility.UrlEncode(di.Name))
                };
                this.Controls.Add(link);
            }
        }
        else // process link click
        {
            string path = HttpUtility.UrlDecode(dir); // check for null, etc
            new DirectoryInfo(path).Delete();
        }
    }
