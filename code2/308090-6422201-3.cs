    string path = @"d:\Temp";
    protected override void OnInit(EventArgs e)
    {
        string dir = this.Request["dir"];
        if (String.IsNullOrEmpty(dir)) // write links
        {
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
            dir = HttpUtility.UrlDecode(dir);
            path = Path.Combine(path, dir);
            Directory.Delete(path);
            Response.Redirect("~/Default.aspx"); // page's name to refresh content
        }
    }
