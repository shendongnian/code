    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
       newtb.Columns.Add("Id", typeof(int));
       newtb.Columns.Add("FileName", typeof(string));
       newtb.Columns.Add("FilePath", typeof(string));
       newtb.Columns.Add("Index", typeof(int));
       List<ArrayList> t = new List<ArrayList>();
        if (newpath.Count > 0)
        {
            t = newpath;
            newpath = t;
            for (int i = 0; i < newpath.Count; i++)
            {
                ArrayList alst = newpath[i];
                newtb.Rows.Add(Convert.ToInt32(alst[0]), alst[1].ToString(), alst[2].ToString(), i);
            }
            ViewState["tempimage"] = newpath;
            dlstSelectedImages.DataSource = newtb;
            DataBind();
        }
      }
    }
