    private void BindData(int id)
    {
                TestLinq2SqlVs1DataContext dt = new TestLinq2SqlVs1DataContext();
                var tr = from r in dt.Users
                         join s in dt.Entities on r.Entity_ID equals s.ID
                         where s.ID == id                     select new
                         {
    
    
                         };
    
                gvShowRegistration.DataSource = tr;
                gvShowRegistration.DataBind();
    }
