    protected void Page_Load(object sender, EventArgs e)
    {
        string getEntity = Request.QueryString["EntityID"];
        int getIntEntity = Int32.Parse(getEntity);
        OISLinqtoSQLDataContext db = new OISLinqtoSQLDataContext();
        var tr = from r in db.Users
                 join s in db.Entities on r.UserID equals s.ID
                 where s.ID == getIntEntity
                 select new
                 {
                     //To Show Items in GridView!
                 };
        GridView1.DataSource = tr;
        GridView1.DataBind();
    }
