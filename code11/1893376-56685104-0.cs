    private void Execute<T, T1>(ref List<T> obj, ref List<T1> obj1, string sql, params object[] parameters) where T : class
    {
        using (var db = _context)
        {
    
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            try
            {
                db.Database.Connection.Open();
                using (var reder = cmd.ExecuteReader())
                {
                    obj = ((IObjectContextAdapter)db).ObjectContext.Translate<T>(reder).ToList();
    				if(obj1 != null) {
    					reder.NextResult();
    	                obj1 = ((IObjectContextAdapter)db).ObjectContext.Translate<T1>(reder).ToList();
    				}                
                }
            }
            finally
            {
                db.Database.Connection.Close();
                cmd.Dispose();
            }
        }
    }
    public void ExecuteList<T, T1>(out List<T> obj, out List<T1> obj1, string sql, params object[] parameters) where T : class
    {
    	obj = new List<T>();
    	obj1 = new List<T1>();
    	Execute(ref obj, ref obj1, sql, parameters);
    }
    
    public void ExecuteList<T>(out List<T> obj, string sql, params object[] parameters) where T : class
    {
    	obj = new List<T>();
    	List<object> stub = null;
    	Execute<T, object>(ref obj, ref stub, sql, parameters);
    } 
