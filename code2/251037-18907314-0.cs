    mytable = new DataTable();
    SQLiteCommand command = DBconnection.CreateCommand();
    command.CommandText = "select * from V_FullView";
    SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
    mytable.Load(reader);
    mytable.Constraints.Clear();
    reader = command.ExecuteReader();
    mytable.Load(reader);
    reader.Close();
