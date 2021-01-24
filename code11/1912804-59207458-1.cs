        StringBuilder sCommand = new StringBuilder("create temporary table tablename(");
        foreach (var Col in source_db_table .Columns)
        {
          sCommand.Append("`"+Col+"`" + " varchar(200), ");
        }
        sCommand.Append(");");
        string scmd = ReplaceLastOccurrence(sCommand.ToString(), ",", "");
