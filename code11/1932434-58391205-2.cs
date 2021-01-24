    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {
        MethodInfo nonGenMethodCreate = typeof(SQLiteConnection).GetMethod("CreateTable");
        MethodInfo nonGenMethodDeleteAll = typeof(SQLiteConnection).GetMethod("DeleteAll");
        MethodInfo nonGenMethodInsertAll = typeof(SQLiteConnection).GetMethod("InsertAll");
    
        foreach(Type t in Assembly.GetExecutingAssembly.GetTypes()) {
            MethodInfo genMethodCreate = nonGenMethodCreate.MakeGenericMethod(t);
            MethodInfo genMethodDeleteAll = nonGenMethodDeleteAll.MakeGenericMethod(t);
            MethodInfo genMethodInsertAll = nonGenMethodInsertAll.MakeGenericMethod(t);
    
            genMethodCreate.Invoke(conn, null);
            genMethodDeleteAll.Invoke(conn, null);
            genMethodInsertAll.Invoke(conn, new[] { data });
    
        }
    }
