    using DBContext db = new DBCntext())
    {
        dataGridView.DataSource = db.Activitys
            .Include(a => a.User)
            .Include(a => a.System)
            .Select(a => new MyModel {
                MyModel.ActivityID = a.ActivityID,
                MyModel.Version= a.Version,
                MyModel.Date = a.Date ,
                MyModel.Changes = a.Changes,
                MyModel.UserName = a.User.Name,
                MyModel.SysType= a.System.SysType
            })
            .ToList();
    }
