            string getEntity = Request.QueryString["EntityID"];
            int getIntEntity = Int16.Parse(getEntity);
            TestLinq2SqlVs1DataContext dt = new TestLinq2SqlVs1DataContext();
            var tr = from r in dt.Users
                     join s in dt.Entities on r.Entity_ID equals s.ID
                     where s.ID == getIntEntity
                     select new
                     {
                     };
            gvShowRegistration.DataSource = tr;
            gvShowRegistration.DataBind();
