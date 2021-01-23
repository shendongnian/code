      protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] dd = { "FullName" };
                FilesGrid.DataKeyNames = dd;
    
                string appPath = Request.PhysicalApplicationPath;
                DirectoryInfo dirInfo = new DirectoryInfo(appPath);
                FileInfo[] files = dirInfo.GetFiles();
                FilesGrid.DataSource = files;
                FilesGrid.DataBind();
            }
        }
        protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = FilesGrid.SelectedIndex; // selected = 2
            //FilesGrid.DataBind();  //added after feedback in comments. it makes no change
            int count = FilesGrid.Rows.Count; // count = 0
            GridViewRow row = FilesGrid.Rows[selected]; // row = null
            GridViewRow row0 = FilesGrid.Rows[0]; // row = null
        }
        protected void FilesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
    
        }
        protected void FilesGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
    
        }
