    public List<Object> GetProjectForCombo()
    {
        using (MyDataContext db = new MyDataContext (DBHelper.GetConnectionString()))
         {
             var query = from pro in db.Projects
                         select new {pro.ProjectName,pro.ProjectId};
             return query.ToList<Object>();
        }
    }
