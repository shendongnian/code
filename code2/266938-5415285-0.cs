    OISLinqtoSQLDataContext db = new OISLinqtoSQLDataContext();
            var tr = from r in db.Users
                     join s in db.Entities on r.UserID equals s.ID
                     where s.ID = Convert.ToInt32(Request.QueryString["EntityID"])
                     select new
                     {
                         //To Show Items in GridView!
                     };
        GridView1.DataSource = tr;
        GridView1.DataBind();
