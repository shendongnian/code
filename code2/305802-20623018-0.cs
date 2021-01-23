    public List<Object> GetProjectForCombo()
    {
       using (MyDataContext db = new MyDataContext (DBHelper.GetConnectionString()))
       {
         var query = db.Project
         .Select<IEnumerable<something>,ProjectInfo>(p=>
                     return new ProjectInfo{Name=p.ProjectName, Id=p.ProjectId);       
         return query.ToList<Object>();
       }
   }
 
