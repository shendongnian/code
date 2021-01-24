        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new SampleDatabaseEntities())
            {
                var data = db.Prodcts.ToList();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }
