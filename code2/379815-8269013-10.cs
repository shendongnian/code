    protected void Page_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string path = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/feed.htm");
    
            Stream stream = client.OpenRead(path);
            StreamReader sr = new StreamReader(stream);
            //To view the result
            Label1.Text = sr.ReadToEnd();
        }
