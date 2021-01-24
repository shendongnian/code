    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }
    
    public void BindGrid()
    {
        var sess = Session["username"].ToString();
        string a = sess.Substring(sess.Length - 1);
    
        SqlDataAdapter adp = new SqlDataAdapter("select * from dojoquiz order by " + a + "", ConfigurationManager.ConnectionStrings["dashboardConnectionString"].ToString());
        adp.Fill(dt);
    
        grdquestions.DataSource = dt;
        
        if (!Page.IsPostBack)
            grdquestions.DataBind();
    }
