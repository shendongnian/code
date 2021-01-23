    class ProjectInfo
    {
        public string Name {get; set; }
        public long Id {get; set; }
        ProjectInfo(string n, long id)
        {
            name = n;   Id = id;
        }
    }
    public List<ProjectInfo> GetProjectForCombo()
    {
        using (MyDataContext db = new MyDataContext (DBHelper.GetConnectionString()))
        {
             var query = from pro in db.Projects
                        select new ProjectInfo(pro.ProjectName,pro.ProjectId);
             return query.ToList<ProjectInfo>();
        }
    }
