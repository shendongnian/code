    cntDB = new ContextDB();
     List<string> lst_List = new List<string>();
     public void Method_2(string nameTable, string nameField)
            {
                var lst_List = cntDB.Database.SqlQuery<string>("SELECT " + nameField + " FROM " + nameTable).ToList();
            }
