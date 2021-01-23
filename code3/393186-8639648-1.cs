    protected void Page_Load(object sender, EventArgs e)
        {
            ListImages();
        }
    
        private void ListImages()
        {
            DirectoryInfo dir = new DirectoryInfo(MapPath("~/images"));
            FileInfo[] file = dir.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo file2 in file)
            {
                if (file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif")
                {
                    list.Add(file2);
                }
            }
            DataList1.DataSource = list;
            DataList1.DataBind();
        }
