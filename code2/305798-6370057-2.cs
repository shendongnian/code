    class ProjectInfo
    {
       public string Name {get; set; }
       public long Id {get; set; }
    }
    
    public List<ProjectInfo> GetProjectForCombo()
    {
        using (MyDataContext db = new MyDataContext (DBHelper.GetConnectionString()))
        {
            var query = from pro in db.Projects
                        select new ProjectInfo(){ Name = pro.ProjectName, Id = pro.ProjectId };
    
            return query.ToList();
        }
    }
