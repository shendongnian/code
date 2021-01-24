    public DatabaseProperty MyNewBindableDB {get;set;}
      
    List<DatabaseProperty> dbList = new List<DatabaseProperty>();    
            foreach(Database db in srv1.Databases)
            {
                DatabaseProperty newDB = new DatabaseProperty();
                newDB.DBName = db.Name.ToString();
                // Get the DB's users
                //List<DBUser> dbUserList = new List<DBUser>();
                for (int i = 0; i < srv1.Logins.Count; i++)
                {
                    // DatabaseProperty class contains a DBUser enumberable list
                    DBUser newdbUser = new DBUser();
                    //newDB.DBUserList[i].UserName = srv1.Logins[i].Name;
                    newdbUser.UserName = srv1.Logins[i].Name;
                    newDB.DBUserList.Add(newdbUser);
                }
                dbList.Add(newDB);
            }
           MyNewBindableDB = dbList.FirstOrDefault(); //gets one list from your 
            //list of <DatabaseProperty>. 
