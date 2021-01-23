    database.dbDataContext db = new database.dbDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
    List<database.User> data = db.Users.ToList();
     for (int i = 0; i < data.Count; i++)
     {
         var a = data[i].Field1;
         var b = data[i].Field2;    
         ...
     }
    }
