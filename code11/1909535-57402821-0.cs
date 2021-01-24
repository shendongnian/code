    private class GenericController
        {
            private CoreGradingDBEntities db = new CoreGradingDBEntities();
            public dynamic Get(string Table, string Field, string id)
            {
                var task = db.Database.SqlQuery(Type.GetType(Table), "SELECT * FROM " + Table + " WHERE " + Field + " = '" + id + "';").ToListAsync();
				dynamic str = task.Result;
                return  str;
            }
        }
