    List<MyPanel> list_panel = new List<MyPanel>();
    List<string> list_sql = new List<string>();
    object listSqlLock = new object();
    Parallel.For(0, list_panel.Count, i =>
    {
        if (list_panel[i].R == 0)
        {
            var sqlCommands = list_panel[i].MakeSqlForSave();
            lock (listSqlLock)
                list_sql.AddRange(sqlCommands);
        }
    });
