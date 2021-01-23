         public List<ProjectInfo> GetProjectForCombo()
          {
        using (MyDataContext db = new MyDataContext 
        (DBHelper.GetConnectionString()))
             {
            return  (from pro in db.Projects
                        select new { query  }.query).ToList();
            }
          }
